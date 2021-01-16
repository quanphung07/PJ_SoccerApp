using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SoccerManageApp.Dtos;
using SoccerManageApp.Models.Entities;

namespace SoccerManage.Data
{
    public interface IDataRepo
    {
        //Team Data
        Task<Team> GetTeamByNameAsync(string name);
        Task<IEnumerable<TeamDetails>> GetTeamByName_withSearchAsync(string name,string search);
        Task<int> CreateTeamAsync(Team team);
        Task<IEnumerable<CreateTeamView>> GetAllTeamsAsync();
        Task<Team> UpdateTeamAsync(Team team,string teamName);
         Task<IEnumerable<TeamDetails>> GetTeamDetailsByNameAsync(string teamName);
         Task DeleteTeamAsync(string teamName);
        
      
                //Player Data
        Task <int> CreatePlayerAsync(Player player,string teamName);
        Task UpdatePlayerAsync(Player player,int playerId);
        Task DeletePlayerAsync(int playerId);
        Task<Player> GetPlayerByNameAsync(string name);
        //Stadium data
        Task<Stadium> GetStadiumByNameAsync(string name);
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        Task<Player> GetPlayerByIdAsync(int? id);
        Task CreateStadiumAsync(Stadium model);
        void GetAllPlayers();
        //match data
        Task<IEnumerable<MatchInfoDtos>> GetAllMatchAsync();
        Task<int> CreateMatchAsync(Match match);
        bool CheckExist(string homeTeam,string awayTeam);
        Task<MatchInfoDtos> GetMatchByIdAsync(int matchId);
        Task<IEnumerable<MatchInfoDtos>> GetMatchByDatetimeAsync(DateTime date);
        Task<Match> GetMatchWithHomeAndAwayTeamAsync(string home,string away);

        //result data
        Task<int> CreateResultAsync(Result result,int matchId);
        Task<IEnumerable<RankingDto>> GetRankAsync();
        //score data
        Task<IEnumerable<Score>> GetScores(int matchId);
        Task<int> CreateScoreAsync(Score score);
        //user
        
        
    }
}