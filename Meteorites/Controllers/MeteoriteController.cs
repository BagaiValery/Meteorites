using Meteorites.Data;
using Meteorites.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Meteorites.Controllers
{
    public class MeteoriteController : Controller
    {
        //private static List<MeteoriteViewModel> meteorites = new List<MeteoriteViewModel>();
        private readonly ApplicationDbContext _db;

        public MeteoriteController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MeteoriteViewModel> meteor = _db.Meteorites;
            return View(meteor);
        }

        public IActionResult Dowload()
        {
            return View();
        }

        public async Task<RedirectToActionResult> DowloadData()
        {
            var data = new Parser();
            var meteor = await data.GetData();
            //meteorites.AddRange(meteor);
            
            foreach (var meteorite in meteor)
            {
                meteorite.geolocDB.type = meteorite.geolocation.type;
                meteorite.geolocDB.coordinateX = meteorite.geolocation.coordinates[0];
                    meteorite.geolocDB.coordinateY = meteorite.geolocation.coordinates[1];
            }


            //_db.Meteorites.AddRange(meteor);
            _db.Meteorites.UpdateRange(meteor);
            _db.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }


    }
}
