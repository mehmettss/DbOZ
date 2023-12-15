using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbOZ.Models.Entity;
using DbOZ.Repositories;

namespace DbOZ.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<Tbl_Sertfika> repo = new GenericRepository<Tbl_Sertfika>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika =repo.Find(x=>x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }
		[HttpPost]
		public ActionResult SertifikaGetir(Tbl_Sertfika t)
        {
			var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.Aciklama=t.Aciklama;
            sertifika.Tarih=t.Tarih;
            repo.voidTUpdate(sertifika);
			return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
		[HttpPost]
		public ActionResult YeniSertifika(Tbl_Sertfika p)
		{
            repo.TAdd(p);

			return RedirectToAction("index");
		}
        public ActionResult SertifikaSil(int id)
        {
           
            var sertifika = repo.Find(x=>x.ID == id);
            repo.TRemove(sertifika);
            return RedirectToAction("Index");
        }

	}
}