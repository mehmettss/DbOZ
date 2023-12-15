using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbOZ.Models.Entity;
using DbOZ.Repositories;

namespace DbOZ.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim
        GenericRepository<Tbl_iletisim> repo = new GenericRepository<Tbl_iletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}