using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbOZ.Models.Entity;

namespace DbOZ.Controllers
{
	[AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_hakkimda.ToList();
            return View(degerler);
        }
		public PartialViewResult SosyalMedya() 
		{
			var sosyalmedya = db.Tbl_SosyalMedya.Where(x=>x.Durum==true).ToList();
			return PartialView(sosyalmedya);
		}
		public PartialViewResult Deneyim()
        {
            var deneyimler = db.Tbl_Deneyimler.ToList();
            return PartialView(deneyimler);
        }
		public PartialViewResult Egitimlerim()
		{
			var egitimler= db.Tbl_Egitimlerim.ToList();
			return PartialView(egitimler);
		}
		public PartialViewResult Yeteneklerim()
		{
			var yetenekler = db.Tbl_yeteneklerim.ToList();
			return PartialView(yetenekler);
		}
		public PartialViewResult Hobilerim()
		{
			var hobiler = db.Tbl_hobilerim.ToList();
			return PartialView(hobiler);
		}
		public PartialViewResult Sertfikalarim()
		{
			var Sertfika = db.Tbl_Sertfika.ToList();
			return PartialView(Sertfika);
		}
		[HttpGet]
		public PartialViewResult İletisim()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult İletisim(Tbl_iletisim t)
		{
			t.Tarih=DateTime.Parse( DateTime.Now.ToShortDateString());
			db.Tbl_iletisim.Add(t);
			db.SaveChanges();
			return PartialView();
		}
	}
}