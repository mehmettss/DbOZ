using DbOZ.Models.Entity;
using DbOZ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbOZ.Controllers
{
    public class HakkimdaController : Controller
    {
		// GET: Hakkimda
		GenericRepository<Tbl_hakkimda> repo = new GenericRepository<Tbl_hakkimda>();
		[HttpGet]
		public ActionResult Index()
		{
			var hakkimda = repo.List();
			return View(hakkimda);
		}
		[HttpPost]
		public ActionResult Index(Tbl_hakkimda p)
		{
			var t = repo.Find(x => x.ID == 1);
			t.Ad = p.Ad;
			t.Soyad = p.Soyad;
			t.Adres = p.Adres;
			t.Mail= p.Mail;
			t.Telefon= p.Telefon;
			t.Aciklama = p.Aciklama;
			t.Resim= p.Resim;
			repo.voidTUpdate(t);
			return RedirectToAction("Index");
		}
	}
}