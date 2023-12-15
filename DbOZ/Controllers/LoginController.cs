using DbOZ.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DbOZ.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{

		// GET: Login
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(Tbl_Admin p)
		{
			DbCvEntities db = new DbCvEntities();
			var bilgi = db.Tbl_Admin.FirstOrDefault(x => x.Kullaniciadi == p.Kullaniciadi && x.Sifre == p.Sifre);
			if (bilgi != null)
			{
				FormsAuthentication.SetAuthCookie(bilgi.Kullaniciadi, false);
				Session["KullaniciAdi"] = bilgi.Kullaniciadi.ToString();
				return RedirectToAction("index", "Deneyim");
			}
			else
			{
				return RedirectToAction("index", "Login");
			}
		}
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("index", "Login");
		}

	}
}