using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbOZ.Models.Entity;
using DbOZ.Repositories;

namespace DbOZ.Controllers
{
    public class HobilerController : Controller
    {
        // GET: Hobiler
        GenericRepository<Tbl_hobilerim> repo = new GenericRepository<Tbl_hobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
		public ActionResult Index(Tbl_hobilerim p)
		{
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama1= p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.voidTUpdate(t);
            return RedirectToAction("Index");
		}
	}
}