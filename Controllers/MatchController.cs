using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerManage.Data;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Controllers
{
    public class MatchController:Controller
    {
        private readonly IDataRepo _repo;
        public MatchController(IDataRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> Index(DateTime date)
        {
            var matches=await _repo.GetMatchByDatetimeAsync(date);
            return View("ListMatches",matches);
        }
        public async Task<IActionResult> ListMatches()
        {
            var matches=await _repo.GetAllMatchAsync();
            return View(matches);
        }
        public IActionResult CreateMatch(bool checkExist=false)
        {
            ViewBag.CheckExist=checkExist;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMatch(Match match)
        {
            bool checkExist=_repo.CheckExist(match.HomeTeamName,match.AwayTeamName);
            if(checkExist)
            {
                return RedirectToAction("CreateMatch",new {checkExist=checkExist});
            }
            await _repo.CreateMatchAsync(match);
            var matchAfter=await _repo.GetMatchWithHomeAndAwayTeamAsync(match.HomeTeamName,match.AwayTeamName);
            
            return RedirectToAction("CreateResult","Result",new {matchId=matchAfter.MatchID});
        }
    }
}