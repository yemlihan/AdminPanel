using AdminPanel.AppCode;
using AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Areas.Admin.Controllers
{
    public class AnasayfaController : Controller
    {
        [Authorize]
        // GET: Admin/Anasayfa
        public ActionResult Index()
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.anasayfa.First();
                return View(model);

            }
        }
        public ActionResult AnasayfaGuncelle()
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.anasayfa.First();
                return View(model);
            }
        }

        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(anasayfa GelenVeri)
        {
            using (site2020Entities db = new site2020Entities())
            {
                var GuncellenecekVeri = db.anasayfa.First();
                if (!ModelState.IsValid)
                {
                    return View("AnasayfaGuncelle", GelenVeri);
                }
                if (GelenVeri.fotoFile != null)
                {
                    GelenVeri.foto = Seo.DosyaAdiDuzenle(GelenVeri.fotoFile.FileName);
                    GelenVeri.fotoFile.SaveAs(Path.Combine(Server.MapPath("~/Content/img"), Path.GetFileName(GelenVeri.foto)));
                }
                db.Entry(GuncellenecekVeri).CurrentValues.SetValues(GelenVeri);
                db.SaveChanges();
                TempData["anasayfaGuncelle"] = "";
                return RedirectToAction("index", "anasayfa");
            }
        }
    }
}