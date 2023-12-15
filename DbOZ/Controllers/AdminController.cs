using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbOZ.Models.Entity;
using DbOZ.Repositories;

namespace DbOZ.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Tbl_Admin> repo = new GenericRepository<Tbl_Admin>();

        public ActionResult Index()
        {
            var liste =repo.List();
            return View(liste);
        }
		[HttpGet]
		public ActionResult AdminEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AdminEkle(Tbl_Admin d)
		{
			repo.TAdd(d);
			return RedirectToAction("Index");
		}
		public ActionResult AdminSil(int id)
		{
			Tbl_Admin t = repo.Find(x => x.ID == id);
			repo.TRemove(t);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult AdminDuzenle(int id)
		{
			Tbl_Admin t = repo.Find(x => x.ID == id);
			return View(t);
		}
		[HttpPost]
		public ActionResult AdminDuzenle(Tbl_Admin p)
		{
			Tbl_Admin t = repo.Find(x => x.ID == p.ID);
			t.Kullaniciadi = p.Kullaniciadi;
			t.Sifre = p.Sifre;
			repo.voidTUpdate(t);
			return RedirectToAction("index");
		}
	}
}