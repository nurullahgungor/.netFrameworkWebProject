using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AyvaDbContext _db;

        public HomeController() {
            _db = new AyvaDbContext();             // "AyvaDbContext" veritabanımın DbContext sınıfımın ismidir.

        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Slider> sliderList = new List<Slider>();
            sliderList = _db.Sliders.ToList();
            

            return View(sliderList);
        }
        
        public ActionResult DagilimGrafigi()
        {
            List<cityGraph> cityData = new List<cityGraph>();            
            cityData = _db.cityGraphs.ToList(); 
            

            return View(cityData);
        }
        
        public ActionResult Sehirler()
        {
            List<cityGraph> cityData = new List<cityGraph>();
            cityData = _db.cityGraphs.ToList();


            return View(cityData);
        }
        
        public ActionResult Turler()
        {
            List<Turler> turler = new List<Turler>();
            turler = _db.Turlers.ToList();


            return View(turler);
            
        }
        public ActionResult Content()
        {
            return View();
        }
    }
}