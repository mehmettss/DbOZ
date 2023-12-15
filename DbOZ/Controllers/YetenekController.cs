using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbOZ.Models.Entity;
using DbOZ.Repositories;

namespace DbOZ.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek

        YetenekRepository repo = new YetenekRepository();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(Tbl_yeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            Tbl_yeteneklerim t =repo.Find(x=>x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
		[HttpGet]
		public ActionResult YetenekDuzenle(int id)
		{
			var yetenek = repo.Find(x => x.ID == id);
			return View(yetenek);
		}
		[HttpPost]
		public ActionResult YetenekDuzenle(Tbl_yeteneklerim p)
		{
			var t = repo.Find(x => x.ID == p.ID);
			t.Yetenek = p.Yetenek;
			t.Oran = p.Oran;
			repo.voidTUpdate(t);
			return RedirectToAction("index");
		}
	}
}
