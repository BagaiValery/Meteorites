using Meteorites.Data;
using Meteorites.Migrations;
using Meteorites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Meteorites.Controllers
{
    public class MeteoriteController : Controller
    {
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

        //Dowloded data frop JSON page
        public async Task<RedirectToActionResult> DowloadData()
        {
            var data = new Parser();
            var meteor = await data.GetData();
            
            //convert coordinates from array to int for DB
            foreach (var meteorite in meteor)
            {
                meteorite.geolocDB.type = meteorite.geolocation.type;
                meteorite.geolocDB.coordinateX = meteorite.geolocation.coordinates[0];
                    meteorite.geolocDB.coordinateY = meteorite.geolocation.coordinates[1];
            }

            //Add data to DB
            if (ModelState.IsValid)
            {
                //_db.Meteorites.AddRange(meteor);
                _db.Meteorites.UpdateRange(meteor);
                _db.SaveChanges();
            }
            
            return RedirectToAction(nameof(Index));
        }

        //Filter by YearRange
        [HttpGet]
        public IActionResult GetMeteoritesByYearRange(int? startYear, int? endYear, string? meteorClass, string orderBy)
        {
            List<MeteoriteViewModel> data = new List<MeteoriteViewModel>();

            if (startYear != null && endYear != null && startYear > endYear)
            {
                return BadRequest("yearFrom must be less than or equal to yearTo");
            }
            if (startYear.HasValue && endYear.HasValue)
            {
                data = _db.Meteorites.Where(d => d.year.Value.Year >= startYear.Value && d.year.Value.Year <= endYear.Value).ToList();
            }
            else if (startYear.HasValue)
            {
                data = _db.Meteorites.Where(d => d.year.Value.Year >= startYear.Value).ToList();
            }
            else if (endYear.HasValue)
            {
                data = _db.Meteorites.Where(d => d.year.Value.Year >= endYear.Value).ToList();
            }
            if (!string.IsNullOrEmpty(meteorClass))
            {
                data = data.Where(d => d.recclass == meteorClass).ToList();
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "year":
                        data = (List<MeteoriteViewModel>)data.OrderBy(d => d.year);
                        break;
                    case "number":
                        data = (List<MeteoriteViewModel>)data.OrderBy(d => d.id).ToList();
                        break;
                    case "totalMass":
                        data = (List<MeteoriteViewModel>)data.OrderBy(d => d.mass).ToList();
                        break;
                    default:
                        return BadRequest("Invalid orderBy parameter");
                }
            }

            return Json(data);
        }

        [HttpGet]
        public IActionResult GetDistinctClasses()
            
        {
            var mclass = _db.Meteorites.Select(m => m.recclass).Distinct().OrderBy(n => n).ToList();
            return Json(mclass);
        }


        //Searcher
        [HttpGet("SearchByName")]
        public async Task<ActionResult<IEnumerable<MeteoriteViewModel>>> SearchByName(string nameFilter)
        {
            if (!string.IsNullOrEmpty(nameFilter))
            {
                var meteorites = await _db.Meteorites.Where(m => m.name.Contains(nameFilter)).ToListAsync();
                return meteorites;
            }
            return BadRequest("FilterName");
        }

        //Groupe meteorites by year
        [HttpGet]
        [Route("api/meteorites/grouped")]
        public IActionResult GetGroupedMeteorites(string sort = "year")
        {
           List<GroupedMeteorite> groupedMeteorite = _db.Meteorites
            .Where(m => m.year.HasValue)
            .GroupBy(m => m.year.Value.Year)
            .Select(g => new GroupedMeteorite
            {
                 Year = g.Key,
                 Quantity = g.Count(),
                 TotalWeight = g.Sum(m => m.mass)
            })
            .OrderBy(g => g.Year).ToList();

            return View(groupedMeteorite);
        }
    }
}
