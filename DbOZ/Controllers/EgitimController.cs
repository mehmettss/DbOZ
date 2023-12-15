using DbOZ.Models.Entity;
using DbOZ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbOZ.Controllers
{
	[Authorize]
	public class EgitimController : Controller
    {
      GenericRepository<Tbl_Egitimlerim> repo = new GenericRepository<Tbl_Egitimlerim> ();
        // GET: Egitim
        public ActionResult Index( )
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Egitimlerim p)
        {
            if (!ModelState.IsValid) 
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x=>x.ID == id);
            repo.TRemove(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x=>x.ID == id);
            return View(egitim);
        }
        [HttpPost]
		public ActionResult EgitimDuzenle(Tbl_Egitimlerim t)
		{
			if (!ModelState.IsValid)
			{
				return View("EgitimDuzenle");
			}
			var egitim = repo.Find(x => x.ID == t.ID);
			egitim.Baslik = t.Baslik;
			egitim.AltBaslik1 = t.AltBaslik1;
			egitim.AltBaslik2 = t.AltBaslik2;
			egitim.GNO = t.GNO;
			egitim.Tarih = t.Tarih;
			repo.voidTUpdate(t);
			return RedirectToAction("index");
		}
	}
}