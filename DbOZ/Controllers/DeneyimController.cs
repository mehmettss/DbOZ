using DbOZ.Models.Entity;
using DbOZ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DbOZ.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult DeneyimEkle(Tbl_Deneyimler d)
        {
            repo.TAdd(d);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            Tbl_Deneyimler t=repo.Find(x=>x.ID==id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
			Tbl_Deneyimler t = repo.Find(x => x.ID == id);
            return View(t);
		}
		[HttpPost]
		public ActionResult DeneyimGetir(Tbl_Deneyimler p)
		{
			Tbl_Deneyimler t = repo.Find(x => x.ID == p.ID);
            t.Baslık = p.Baslık;
            t.AltBaslik=p.AltBaslik;
            t.Aciklama=p.Aciklama;
            t.Tarih=p.Tarih;
            repo.voidTUpdate(t);
            return RedirectToAction("index");
		}
	}
}