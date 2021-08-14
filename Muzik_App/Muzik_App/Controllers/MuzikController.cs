using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Muzik_App.Models;

using Muzik_App.Controllers;

namespace Muzik_App.Controllers
{
    public class MuzikController : Controller
    {
        // GET: Muzik

        MUZIKEntities db = new MUZIKEntities();
        public ActionResult Index()
        {

            var muzikler = db.TBLMUZIK.ToList();
            return View(muzikler);
        }

        [HttpGet]
        public ActionResult MuzikEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MuzikEkle(TBLMUZIK m)
        {
            db.TBLMUZIK.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MuzikSil(int id)
        {
            var muzik = db.TBLMUZIK.Find(id);
            db.TBLMUZIK.Remove(muzik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MuzikGetir(int id)
        {
            var mzk = db.TBLMUZIK.Find(id);
            return View("MuzikGetir", mzk);
        }

        public ActionResult MuzikGuncelle(TBLMUZIK m)
        {
            var muzik = db.TBLMUZIK.Find(m.MUZIKID);
            muzik.MUZIKID = m.MUZIKID;
            muzik.SARKIADI = m.SARKIADI;
            muzik.ARTIST = m.ARTIST;
            muzik.ALBUMADI = m.ALBUMADI;
            muzik.SARKISURESI = m.SARKISURESI;
            muzik.CIKISYILI = m.CIKISYILI;
            muzik.TUR = m.TUR;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}