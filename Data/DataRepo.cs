using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SoccerManageApp.Dtos;
using SoccerManageApp.Models;
using SoccerManageApp.Models.Entities;
using SoccerManageApp.Models.Entities.Models;

namespace SoccerManage.Data {
    public class DataRepo : IDataRepo {
        private readonly AppDbContext _context;
        public DataRepo (AppDbContext context) {
            _context = context;
        }

        public async Task<int> CreatePlayerAsync (Player player,string teamName) {
            NpgsqlConnection conn = null;
            int row;
            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {

                var cmdStr = "Insert into player(first_name,last_name,kit,position,country_image,country,team_name,age) values" +
                    " (@firstname,@lastname,@kit,@position,@countryimage,@country,@teamname,@age);";

                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    cmd.Parameters.Add ("@firstname", NpgsqlTypes.NpgsqlDbType.Text).Value = player.FirstName;
                    cmd.Parameters.Add ("@lastname", NpgsqlTypes.NpgsqlDbType.Text).Value = player.LastName;
                    cmd.Parameters.Add ("@kit", NpgsqlTypes.NpgsqlDbType.Integer).Value = player.Kit;
                    cmd.Parameters.Add ("@position", NpgsqlTypes.NpgsqlDbType.Text).Value = player.Position;
                    cmd.Parameters.Add ("@age", NpgsqlTypes.NpgsqlDbType.Integer).Value = player.Age;
                    cmd.Parameters.Add ("@country", NpgsqlTypes.NpgsqlDbType.Text).Value = player.Country;
                    cmd.Parameters.Add ("@countryimage", NpgsqlTypes.NpgsqlDbType.Text).Value = player.CountryImage;
                    cmd.Parameters.Add ("@teamname", NpgsqlTypes.NpgsqlDbType.Text).Value = player.TeamName;
                    row = await cmd.ExecuteNonQueryAsync ();

                }

            }
            return row;
        }

        public bool CheckExist (string homeName, string awayName) {
            var check = _context.Matches.Any(m => m.HomeTeamName == homeName && m.AwayTeamName== awayName);
            return check;
        }
        public async Task<int> CreateMatchAsync (Match match) {
            var connStr = DbConnection.connectionString;
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into match(datetime,attendance,stadium_id,awayteam_name,hometeam_name) values " +
                    "(@datetime,@attendance,@stadiumid,@awayname,@homename);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@datetime", match.Datetime);
                    cmd.Parameters.AddWithValue ("@attendance", match.Attendance);
                    cmd.Parameters.AddWithValue ("@homename", match.HomeTeamName);
                    cmd.Parameters.AddWithValue ("@awayname", match.AwayTeamName);
                    cmd.Parameters.AddWithValue ("@stadiumid", match.StadiumID);
                    await conn.OpenAsync();
                    rows = await cmd.ExecuteNonQueryAsync ();
                }
            }
            return rows;

            
        }

        public async Task<int> CreateResultAsync (Result result,int matchId) {
            var connStr = DbConnection.connectionString;
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into result values(@matchid,@homeres,@awayres);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@matchid", result.MatchID);
                    cmd.Parameters.AddWithValue ("@homeres", result.Homeres);
                    cmd.Parameters.AddWithValue ("@awayres", result.Awayres);

                    await conn.OpenAsync ();
                    rows = await cmd.ExecuteNonQueryAsync ();
                }
            }
            return rows;
        }

        public async Task<int> CreateScore (Score score) {
            var connStr = DbConnection.connectionString;
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into score values(@scoreid,@matchid,@playerid,@teamname);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@scoreid", score.ScoreID);
                    cmd.Parameters.AddWithValue ("@matchid", score.MatchID);
                    cmd.Parameters.AddWithValue ("@playerid", score.PlayerID);
                    cmd.Parameters.AddWithValue ("@teamname", score.TeamName);

                    await conn.OpenAsync ();
                    rows = await cmd.ExecuteNonQueryAsync ();

                }
            }
            return rows;

        }

        public async Task<int> CreateTeamAsync (Team team) {
            var connStr = DbConnection.connectionString;
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into team values(@teamname,@teamimage,@stadiumid,@creator);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {

                    cmd.Parameters.AddWithValue ("@teamname", team.TeamName);
                    cmd.Parameters.AddWithValue ("@teamimage", team.TeamImage);
                    cmd.Parameters.AddWithValue ("@stadiumid", team.StadiumID);
                    cmd.Parameters.AddWithValue ("@creator", team.CreatorID);

                    await conn.OpenAsync ();
                    rows = await cmd.ExecuteNonQueryAsync ();

            
                }
            }
            return rows;
        }

        public async Task<IEnumerable<MatchInfoDtos>> GetAllMatchAsync () {

            List<MatchInfoDtos> matches = new List<MatchInfoDtos> ();
            var connStr = DbConnection.connectionString;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "select * from match_info_dto";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                        var match = new MatchInfoDtos () {
                        MatchID = Convert.ToInt32(rd["match_id"]),
                        Datetime = rd.GetDateTime ("datetime"),
                        Attendance = rd.GetInt32 ("attendance"),
                        HomeName = rd.GetString ("hometeam_name"),
                        AwayName = rd.GetString ("awayteam_name"),
                        StadiumName = rd.GetString ("stadium_name"),
                        HomeRes = rd.GetInt32 ("home_res"),
                        AwayRes = rd.GetInt32 ("away_res"),
                        HomeImage = rd.GetString ("home_image"),
                        AwayImage = rd.GetString ("away_image")

                            };
                            matches.Add (match);
                        }
                    }

                }
            }

            return matches;
        }

        public void GetAllPlayers () {
            NpgsqlConnection conn = null;
            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {
                conn.Open ();
                var cmdStr = "Select * from player";
                NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn);
                using (NpgsqlDataReader rd = cmd.ExecuteReader ()) {
                    while (rd.Read ()) {
                        Console.WriteLine ("{0},{1},{2}", rd[0], rd[1], rd[2]);
                    }
                }

            }
        }

        public async Task<IEnumerable<CreateTeamView>> GetAllTeamsAsync () {
            NpgsqlConnection conn = null;
            List<CreateTeamView> list = new List<CreateTeamView> ();
            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Select * from team_dto";
                using (NpgsqlCommand command = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync ()) {
                        while (reader.Read ()) {
                        var team = new CreateTeamView () {

                       
                        TeamName = reader["team_name"].ToString(),
                        TeamImage = reader["team_image"].ToString (),
                         StadiumID = Convert.ToInt32(reader["stadium_id"]),
                        StadiumName = reader["stadium_name"].ToString ()

                            };
                            list.Add (team);
                        }
                    }
                }

            }
            return list;

        }

        public async Task<IEnumerable<MatchInfoDtos>> GetMatchByDatetimeAsync (DateTime date) {
            var connStr = DbConnection.connectionString;
            var cmdStr = "Select * from match_info_dto where datetime=@datetime;";
            var matches = new List<MatchInfoDtos> ();
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync();
                    cmd.Parameters.AddWithValue ("@datetime", date);
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync()) {
                        while (rd.Read ()) {
                       var match = new MatchInfoDtos () {
                        MatchID = Convert.ToInt32(rd["match_id"]),
                        Datetime = rd.GetDateTime ("datetime"),
                        Attendance = rd.GetInt32 ("attendance"),
                        HomeName = rd.GetString ("hometeam_name"),
                        AwayName = rd.GetString ("awayteam_name"),
                        StadiumName = rd.GetString ("stadium_name"),
                        HomeRes = rd.GetInt32 ("home_res"),
                        AwayRes = rd.GetInt32 ("away_res"),
                        HomeImage = rd.GetString ("home_image"),
                        AwayImage = rd.GetString ("away_image")


                            };
                            matches.Add (match);
                        }
                    }

                }
            }
            return matches;
        }

        public async Task<MatchInfoDtos> GetMatchByIdAsync (int matchId) {
            MatchInfoDtos match = new MatchInfoDtos ();
            NpgsqlConnection conn = null;
            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "select * from match_info_dto where match_id=@matchid;";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@matchid", matchId);
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {

                        while (rd.Read ()) {

                         match = new MatchInfoDtos () {
                        MatchID = Convert.ToInt32(rd["match_id"]),
                        Datetime = rd.GetDateTime ("datetime"),
                        Attendance = rd.GetInt32 ("attendance"),
                        HomeName = rd.GetString ("hometeam_name"),
                        AwayName = rd.GetString ("awayteam_name"),
                        StadiumName = rd.GetString ("stadium_name"),
                        HomeRes = rd.GetInt32 ("home_res"),
                        AwayRes = rd.GetInt32 ("away_res"),
                        HomeImage = rd.GetString ("home_image"),
                        AwayImage = rd.GetString ("away_image")

                        };
                    }
                    }
                }
            }


            return match;
    }



        public Player GetPlayerById (int? id) {
            return _context.Players
                .Include (t => t.Team).AsNoTracking ()
                .FirstOrDefault (p => p.PlayerID == id);
        }

        public async Task<Player> GetPlayerByIdAsync (int? id) {
            var player = await _context.Players.FirstOrDefaultAsync (p => p.PlayerID == id);
            return player;
        }

        public async Task<IEnumerable<Score>> GetScores (int matchId) {
            var scores = await _context.Scores.Where (m => m.MatchID == matchId)
                .Include (p => p.Player)
                .Include (t => t.Team)
                .AsNoTracking ().ToListAsync ();
            return scores;
        }

        public async Task<StadiumDetail> GetStadiumByNameAsync (string name) {
            var connStr = DbConnection.connectionString;
            var cmdStr = "Select * from stadium_team where stadium_name=@name";
            StadiumDetail stadium =null;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@name", name);
                     await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        stadium=new StadiumDetail();
                        while (rd.Read ()) {
                            stadium.StadiumName=rd["stadium_name"].ToString();
                            stadium.HomeTeam=rd["team_name"].ToString();
                            stadium.Capacity=Convert.ToInt32(rd["capacity"]);
                            stadium.City=rd["city"].ToString();
                            stadium.TeamImage=rd["team_image"].ToString();
                        }
                    }
                }
            }
            return stadium;

                    

        }


        public async Task<IEnumerable<TeamDetails>> GetTeamByName_withSearchAsync (string name, string search) {
            var connStr = DbConnection.connectionString;
            var cmdStr = "Select * from getteambynamewithsearch(@name,@search);";
            List<TeamDetails> teams = null;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@name", name);
                    cmd.Parameters.AddWithValue ("@search", search);
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            var team = new TeamDetails ();
                            team.TeamName = rd["TeamName"].ToString ();
                            team.TeamImage = rd["TeamImage"].ToString ();
                            team.FirstName = rd["FirstName"].ToString ();
                            team.LastName = rd["LastName"].ToString ();
                            team.Position = rd["position"].ToString ();
                            team.CountryImage = rd["CountryImage"].ToString ();
                            teams.Add (team);
                        }
                    }

                }
            }
            return teams;
        }

        public bool SaveChanges () {
            return _context.SaveChanges () > 0;
        }

        public async Task<bool> SaveChangesAsync () {
            return await _context.SaveChangesAsync () > 0;
        }

        public async Task UpdatePlayerAsync (Player model,int playerId) {
             NpgsqlConnection conn = null;
            var cmdStr = "update player set kit = @kit, position = @position , country = @country, country_image = @countryimage where player_id=@playerId;";

            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
        
                    cmd.Parameters.AddWithValue ("@kit", model.Kit);
                    cmd.Parameters.AddWithValue ("@position", model.Position);
                    cmd.Parameters.AddWithValue("@countryimage",model.CountryImage);
                    cmd.Parameters.AddWithValue("@country",model.Country);
                    cmd.Parameters.AddWithValue("@playerId",playerId);
                    await conn.OpenAsync ();
                    await cmd.ExecuteNonQueryAsync ();
                }
            }
        
        }

        public async Task<Team> GetTeamByNameAsync (string name) {
            
            return await _context.Teams.FirstOrDefaultAsync(t=>t.TeamName==name);
        }


        public async Task<Team> UpdateTeamAsync (Team model,string teamName) {
            NpgsqlConnection conn = null;
            var cmdStr = "update team set team_image = @teamimage, stadium_id = @stadium_id where team_name=@teamname;";

            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
        
                    cmd.Parameters.AddWithValue ("@teamimage", model.TeamImage);
                    cmd.Parameters.AddWithValue ("@stadiumid", model.StadiumID);
                    cmd.Parameters.AddWithValue("@teamname",teamName);
                    await conn.OpenAsync ();
                    await cmd.ExecuteNonQueryAsync ();
                }
            }
        var team=await _context.Teams.FirstOrDefaultAsync (t => t.TeamName == teamName);
            return team;

        }

        public async Task CreateStadiumAsync(Stadium model)
        {
             var connStr = DbConnection.connectionString;
            var cmdStr = "insert into stadium(stadium_name,capacity,city) values "+
                            "(@name,@capacity,@city);";

           
            using (var conn = new NpgsqlConnection (connStr)) {
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue("@name",model.StadiumName);
                    cmd.Parameters.AddWithValue("@capacity",model.Capacity);
                    cmd.Parameters.AddWithValue("@city",model.City);
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
        }
            }
        }

       
        public Task<Team> GetTeamByIdAsync(int teamId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeamDetails>> GetTeamDetailsByNameAsync(string teamName)
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "select * from team_details where team_name=@name;";
            List<TeamDetails> teams = new List<TeamDetails>() ;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@name", teamName);

                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            var team = new TeamDetails ();
                            team.PlayerID=Convert.ToInt32(rd["player_id"]);
                            team.TeamName = rd["team_name"].ToString ();
                            team.TeamImage = rd["team_image"].ToString ();
                            team.FirstName = rd["first_name"].ToString ();
                            team.LastName = rd["last_name"].ToString ();
                            team.Position = rd["position"].ToString ();
                            team.CountryImage = rd["country_image"].ToString ();
                            team.Country=rd["country"].ToString();
                            teams.Add (team);
                        }
                    }

                }
                
            }
            return teams;
        }

        public async Task DeletePlayerAsync(int playerId)
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "delete from player where player_id=@playerId";
           
            using (var conn = new NpgsqlConnection (connStr)) {
                using(var cmd=new NpgsqlCommand(cmdStr,conn))
                {
                    cmd.Parameters.AddWithValue("@playerId",playerId);
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                
        }
    }

        public async Task DeleteTeamAsync(string teamName)
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "delete from team where team_name=@teamName";
           
            using (var conn = new NpgsqlConnection (connStr)) {
                using(var cmd=new NpgsqlCommand(cmdStr,conn))
                {
                    cmd.Parameters.AddWithValue("@teamname",teamName);
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                
        }
    }

        public async Task<IEnumerable<RankingDto>> GetRankAsync()
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "select * from rank_table";

            List<RankingDto> teams = new List<RankingDto>() ;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {

                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            var team = new RankingDto ();
                            team.WinMatch=Convert.ToInt32(rd["win_match"]);
                            team.DrawMatch = rd.GetInt32("draw_match");
                            team.LoseMatch = rd.GetInt32("lose_match");
                            team.WinMatch = rd.GetInt32("win_match");
                            team.TeamName = rd["team_name"].ToString ();
                             team.TeamImage = rd["team_image"].ToString ();
                            team.GoalFor = rd.GetInt32("goal_for");
                            team.GoalAgainst = rd.GetInt32("goal_againt");
                            team.MatchPlayed=rd.GetInt32("played");
                            team.Point=rd.GetInt32("point");
                            teams.Add (team);
                        }
                    }

                }
            }
            return teams;
        }

        public async Task<Match> GetMatchWithHomeAndAwayTeamAsync(string home, string away)
        {
            return await _context.Matches.FirstOrDefaultAsync(m=>m.AwayTeamName==away && m.HomeTeamName==home);
        }

        public async Task<Player> GetPlayerByNameAsync(string name)
        {

            var connStr = DbConnection.connectionString;
            var cmdStr = "select * from player p where concat(p.first_name,' ',p.last_name)=@name";
            Player player=null;

            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@name", name);
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            player=new Player()
                            {
                                PlayerID=Convert.ToInt32(rd["player_id"]),
                                FirstName=rd["first_name"].ToString(),
                                LastName=rd["last_name"].ToString(),
                                Kit=Convert.ToInt32(rd["kit"]),
                                Position=rd["position"].ToString(),
                                CountryImage=rd["country_image"].ToString(),
                                Country=rd["country"].ToString(),
                                TeamName=rd["team_name"].ToString(),
                                Age=Convert.ToInt32(rd["age"])

                            };
                        }}
                }
            }
            return player;

        }
                   
        public async Task<int> CreateScoreAsync(Score score)
        {
           var connStr = DbConnection.connectionString;
            var cmdStr = "insert into score(match_id,player_id,team_name,is_owngoal) values "+
                            "(@matchid,@playerid,@teamname,@isowngoal);";

            int row=0;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {

                    cmd.Parameters.AddWithValue ("@matchid", score.MatchID);
                    cmd.Parameters.AddWithValue ("@playerid", score.PlayerID);
                    cmd.Parameters.AddWithValue ("@teamname", score.TeamName);
                     cmd.Parameters.AddWithValue ("@isowngoal", score.IsOwnGoal);


                    await conn.OpenAsync ();
                row= await cmd.ExecuteNonQueryAsync ();

        }
            }
            return row;
        }

        public async Task<IEnumerable<TeamDetails>> GetTeamDetailsByCountryAsync(string teamName, string nameCountry)
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "select * from team_details where team_name=@name and country=@country";
            List<TeamDetails> teams = new List<TeamDetails>() ;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@name", teamName);
                    cmd.Parameters.AddWithValue ("@country", nameCountry);
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            var team = new TeamDetails ();
                            team.PlayerID=Convert.ToInt32(rd["player_id"]);
                            team.TeamName = rd["team_name"].ToString ();
                            team.TeamImage = rd["team_image"].ToString ();
                            team.FirstName = rd["first_name"].ToString ();
                            team.LastName = rd["last_name"].ToString ();
                            team.Position = rd["position"].ToString ();
                            team.CountryImage = rd["country_image"].ToString ();
                            team.Country=rd["country"].ToString();
                            teams.Add (team);
                        }
                    }

                }
                
            }
            return teams;
        }

        public bool CheckCreatedTeam(string userId)
        {
            return _context.Teams.Any(u=>u.CreatorID==userId);
        }

        public async Task<Stadium> GetStadiumIdByNameAsync(string name)
        {
            return await _context.Stadiums.FirstOrDefaultAsync(t=>t.StadiumName==name);
        }

        public async Task CreateResultMock()
        {
            var random=new Random();
            int matchId;
            int homeres,awayres;
            
              var connStr = DbConnection.connectionString;
           for(matchId=1;matchId<=173;matchId++)
           {
               homeres=random.Next(0,4);
            awayres=random.Next(0,4);
             using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into result values(@matchid,@homeres,@awayres);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@matchid", matchId);
                    cmd.Parameters.AddWithValue ("@homeres", homeres);
                    cmd.Parameters.AddWithValue ("@awayres", awayres);

                    await conn.OpenAsync ();
                     await cmd.ExecuteNonQueryAsync ();
                }
            }
           }



        }

        public async Task<IEnumerable<MatchSchedules>> GetMatchSchedulesAsync()
        {
           List<MatchSchedules> matches = new List<MatchSchedules> ();
            var connStr = DbConnection.connectionString;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "select * from match_schedules";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                        var match = new MatchSchedules() {
                        MatchID = Convert.ToInt32(rd["match_id"]),
                        Datetime = rd.GetDateTime ("datetime"),
                        Attendance = rd.GetInt32 ("attendance"),
                        HomeName = rd.GetString ("hometeam_name"),
                        AwayName = rd.GetString ("awayteam_name"),
                        StadiumName = rd.GetString ("stadium_name"),
                        HomeImage = rd.GetString ("homae_image"),
                        AwayImage = rd.GetString ("away_image"),
                        Round = Convert.ToInt32(rd["round"])

                            };
                            matches.Add (match);
                        }
                    }

                }
            }

            return matches;
        }

        public async Task<IEnumerable<MatchSchedules>> GetMatchSchedulesByDatetimeAsync(DateTime date)
        {
             var connStr = DbConnection.connectionString;
            var cmdStr = "Select * from match_schedules where datetime=@datetime;";
            var matches = new List<MatchSchedules>() ;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync();
                    cmd.Parameters.AddWithValue ("@datetime", date);
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync()) {
                        while (rd.Read ()) {
                       
                            var match = new MatchSchedules() {
                        MatchID = Convert.ToInt32(rd["match_id"]),
                        Datetime = rd.GetDateTime ("datetime"),
                        Attendance = rd.GetInt32 ("attendance"),
                        HomeName = rd.GetString ("hometeam_name"),
                        AwayName = rd.GetString ("awayteam_name"),
                        StadiumName = rd.GetString ("stadium_name"),
                        HomeImage = rd.GetString ("homae_image"),
                        AwayImage = rd.GetString ("away_image"),
                        Round = Convert.ToInt32(rd["round"])

                            };
                            matches.Add (match);
                        }
                    }

                }
            }
            return matches;
        }

        public async Task<IEnumerable<MatchSchedules>> GetMatchSchedulesByRoundAsync(int round)
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "Select * from match_schedules where round=@round;";
            var matches = new List<MatchSchedules>() ;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync();
                    cmd.Parameters.AddWithValue ("@round", round);
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync()) {
                        while (rd.Read ()) {
                       
                            var match = new MatchSchedules() {
                        MatchID = Convert.ToInt32(rd["match_id"]),
                        Datetime = rd.GetDateTime ("datetime"),
                        Attendance = rd.GetInt32 ("attendance"),
                        HomeName = rd.GetString ("hometeam_name"),
                        AwayName = rd.GetString ("awayteam_name"),
                        StadiumName = rd.GetString ("stadium_name"),
                        HomeImage = rd.GetString ("homae_image"),
                        AwayImage = rd.GetString ("away_image"),
                        Round = Convert.ToInt32(rd["round"])

                            };
                            matches.Add (match);
                        }
                    }

                }
            }
            return matches;
        }

        public async Task<IEnumerable<MatchSchedules>> GetMatchSchedulesByRoundAndTimeAsync(int round, DateTime date)
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "Select * from match_schedules where round=@round and datetime=@date;";
            var matches = new List<MatchSchedules>() ;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync();
                    cmd.Parameters.AddWithValue ("@round", round);
                    cmd.Parameters.AddWithValue ("@date", date);

                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync()) {
                        while (rd.Read ()) {
                       
                            var match = new MatchSchedules() {
                        MatchID = Convert.ToInt32(rd["match_id"]),
                        Datetime = rd.GetDateTime ("datetime"),
                        Attendance = rd.GetInt32 ("attendance"),
                        HomeName = rd.GetString ("hometeam_name"),
                        AwayName = rd.GetString ("awayteam_name"),
                        StadiumName = rd.GetString ("stadium_name"),
                        HomeImage = rd.GetString ("homae_image"),
                        AwayImage = rd.GetString ("away_image"),
                        Round = Convert.ToInt32(rd["round"])

                            };
                            matches.Add (match);
                        }
                    }

                }
            }
            return matches;
        
        }
    }
    }
