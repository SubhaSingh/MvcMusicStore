using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private MvcMusicStoreDB db = new MvcMusicStoreDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Search(string q)
        {
            var artists = GetArtists(q);
            return Json(artists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuickSearch(string term)
        {
            var artists = GetArtists(term).Select(a => new { value = a.Name });
            return Json(artists, JsonRequestBehavior.AllowGet);
        }
        private List<Artist> GetArtists(string searchString)
        {
            return db.Artists
            .Where(a => a.Name.Contains(searchString))
            .ToList();
        }

        public ActionResult DailyDeal()
        {
            var album = GetDailyDeal();
            return PartialView("_DailyDeal", album);
        }
        // Select an album and discount it by 50%
        private Album GetDailyDeal()
        {
            var album = db.Albums
            .OrderBy(a => System.Guid.NewGuid())
            .First();
            album.Price *= 0.5m;
            return album;
        }
    }
}