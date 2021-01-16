using System;

namespace SoccerManageApp.Dtos
{
    public class CreateMatchModel
    {
        public int MatchID { get; set; }

        
        public DateTime Datetime { get; set; }
        public int Attendance { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }

        public string StadiumName { get; set; }
    }
    
}