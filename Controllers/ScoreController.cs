using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerManage.Data;
using SoccerManageApp.Dtos;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Controllers
{
    public class ScoreController:Controller
    {
        private readonly IDataRepo _repo;
        public ScoreController(IDataRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> CreateScore(int matchId,bool success=false)
        {
            ViewBag.matchId=matchId;
            ViewBag.success=success;
            var match=await _repo.GetMatchByIdAsync(matchId);
            ViewBag.matchInfo=match;
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> CreateScore(AddScoreView model,int matchId)
        {
            
            var match=await _repo.GetMatchWithHomeAndAwayTeamAsync(model.HomeName,model.AwayName);
            var player=await _repo.GetPlayerByNameAsync(model.PlayerName);
            var score=new Score()
            {
                MatchID=matchId,
                PlayerID=player.PlayerID,
                TeamName=player.TeamName,
                IsOwnGoal=model.IsOwnGoal

            };
            await _repo.CreateScoreAsync(score);
            
            return RedirectToAction("CreateScore",new {matchId=matchId,success=true});
        }
    }
}