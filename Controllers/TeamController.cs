using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoccerManage.Data;
using SoccerManageApp.Dtos;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Controllers
{
    [Authorize(Roles="User,Admin")]
    public class TeamController:Controller
    {
        private readonly IDataRepo _repo;
         private readonly UserManager<IdentityUser> _userManager;
        public TeamController(IDataRepo repo,UserManager<IdentityUser> userManager)
        {
            _repo=repo;
            _userManager=userManager;
        }
        public async Task<IActionResult> ListTeams()
        {
            var teams=await _repo.GetAllTeamsAsync(); 
            return View(teams);
        }

        public IActionResult CreateTeam(int stadiumID)
        {
            ViewBag.stdId=stadiumID;
            ViewBag.teamId=stadiumID;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamView model,int stadiumID)
        {
            if(!ModelState.IsValid)
            {
                return View("Error");
            }
            var user=await _userManager.FindByNameAsync(model.Creator);
            var team=new Team()
            {
                TeamName=model.TeamName,
                TeamImage=model.TeamImage,
                StadiumID=model.StadiumID,
                CreatorID=user.Id
            };
            var result=await _repo.CreateTeamAsync(team);
            if(result >0)
            {
                return RedirectToAction("ListTeams");
            }
           return View(model);

        }
        public async Task<IActionResult> EditTeam(string teamName)
        {
            ViewBag.teamName=teamName;
            var team=await _repo.GetTeamByNameAsync(teamName);
            return View(team);
        }
        [HttpPost]
        public async Task<IActionResult> EditTeam(Team model,string teamName)
        {
            var team=await _repo.UpdateTeamAsync(model,teamName);
            return RedirectToAction("ListTeams");
 
        }
        public async Task<IActionResult> Details (string teamName)
        {
            var team_details=await _repo.GetTeamDetailsByNameAsync(teamName);
            var team= await _repo.GetTeamByNameAsync(teamName);
            ViewBag.teamName=team.TeamName;
            ViewData["TeamImage"]=team.TeamImage;
            return View(team_details);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTeam(string teamName)
        {
            await _repo.DeleteTeamAsync(teamName);
            return RedirectToAction("ListTeams");
        }
    }
}