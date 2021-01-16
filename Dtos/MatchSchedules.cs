using System;

namespace SoccerManageApp.Dtos
{
    public class MatchSchedules
    {
         public int MatchID { get; set; }
         public int Round{get;set;}

        public DateTime Datetime { get; set; }
        public int Attendance { get; set; }
        public string HomeName { get; set; }
        public string AwayName{ get; set; }
        public string StadiumName { get; set; }
        public string HomeImage{get;set;}
        public string AwayImage { get; set; }
    }
}