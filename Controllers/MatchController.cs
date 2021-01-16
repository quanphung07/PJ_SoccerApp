using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerManage.Data;
using SoccerManageApp.Dtos;
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
        public async Task<IActionResult> CreateMatch(CreateMatchModel match)
        {
            bool checkExist=_repo.CheckExist(match.HomeTeamName,match.AwayTeamName);
            if(checkExist)
            {
                return RedirectToAction("CreateMatch",new {checkExist=checkExist});
            }
            var stadium=await _repo.GetStadiumIdByNameAsync(match.StadiumName);
            var model=new Match()
            {
                Datetime=match.Datetime,
                Attendance=match.Attendance,
                StadiumID=stadium.StadiumID,
                HomeTeamName=match.HomeTeamName,
                AwayTeamName=match.AwayTeamName
            };
            await _repo.CreateMatchAsync(model);
            var matchAfter=await _repo.GetMatchWithHomeAndAwayTeamAsync(match.HomeTeamName,match.AwayTeamName);
            
            return RedirectToAction("CreateResult","Result",new {matchId=matchAfter.MatchID});
        }
        
        public async Task<IActionResult> GetSchedules()
        {
            IEnumerable<MatchSchedules> match=null;
           
            
                match= await _repo.GetMatchSchedulesAsync();
            

            
            return View(match);
        }
       
        public async Task<IActionResult> GetSchedulesBy(DateTime date,int? round)
        {
             IEnumerable<MatchSchedules> match=null;
            if(round==null){
            
                 if(DateTime.Compare(date,new DateTime(0001,1,1,0,0,0))==0)
                 {
                      match= await _repo.GetMatchSchedulesAsync();
                      return View("GetSchedules",match);
                 }
                 else
                 {
                     match=await _repo.GetMatchSchedulesByDatetimeAsync(date);
                     return View("GetSchedules",match);
                 }
            }
            else
            {
                if(DateTime.Compare(date,new DateTime(0001,1,1,0,0,0))==0)
                 {
                      match= await _repo.GetMatchSchedulesByRoundAsync((int)round);
                      return View("GetSchedules",match);
                 }
                 else
                 {
                        match= await _repo.GetMatchSchedulesByRoundAndTimeAsync((int)round,date);
                        return View("GetSchedules",match);
                 }
            }
        

        }
          
        
    }

}