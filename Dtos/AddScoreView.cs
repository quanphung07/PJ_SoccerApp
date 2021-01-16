namespace SoccerManageApp.Dtos
{
    public class AddScoreView
    {
        public int MatchID{get;set;}
        public string HomeName { get; set; }
        public string AwayName { get; set; }
        public string OfTeam{get;set;}
        public string PlayerName { get; set; }
        public bool IsOwnGoal{get;set;}
    }
}