using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerManage.Data;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Controllers
{
    public class StadiumController:Controller
    {
        private readonly IDataRepo _repo;
        public StadiumController( IDataRepo repo)
        {
            _repo=repo;
        }
        public IActionResult CreateStadium()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStadium(Stadium model)
        {
            if(ModelState.IsValid)
            {
                await _repo.CreateStadiumAsync(model);
            }
            var stadium=await _repo.GetStadiumIdByNameAsync(model.StadiumName);
            return RedirectToAction("CreateTeam","Team",new {stadiumID=stadium.StadiumID});
     }
     public async Task<IActionResult> DetailStadium(string stadiumName)
     {
         var stadium=await _repo.GetStadiumByNameAsync(stadiumName);
         return View(stadium);
     }

    }
}