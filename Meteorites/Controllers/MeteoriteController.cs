using Meteorites.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Meteorites.Controllers
{
    public class MeteoriteController : Controller
    {
        private static List<MeteoriteViewModel> meteorites = new List<MeteoriteViewModel>();
        

        public IActionResult Index()
        { 
            
            return View(meteorites);
        }

        public IActionResult Dowload()
        {
            var metor = new MeteoriteViewModel();
            return View(metor);
        }

        //private async Task FromJson()
        //{
        //    var data = new Parser();
        //    var meteor = await data.GetData();
        //    meteorites.AddRange(meteor);
        //}
        public async Task<RedirectToActionResult> DowloadData()
        {
            var data = new Parser();
            var meteor = await data.GetData();
            meteorites.AddRange(meteor);
            return RedirectToAction(nameof(Index));
        }
    }
}
