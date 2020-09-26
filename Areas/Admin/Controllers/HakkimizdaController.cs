using AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.AppCode;
using System.IO;

namespace AdminPanel.Areas.Admin.Controllers
{
    public class HakkimizdaController : Controller
    {
        [Authorize]
        // GET: Admin/Hakkimizda
        public ActionResult Index()
        {

            using (site2020Entities db = new site2020Entities())
            {
                var model = db.hakkimizda.First();
                return View(model);
            }
            
        }

        public ActionResult HakkimizdaGuncelle()
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.hakkimizda.First();
                return View(model);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(hakkimizda GelenVeri)
        {
            using (site2020Entities db = new site2020Entities())
            {
                var GuncellenecekVeri = db.hakkimizda.First();
                if (!ModelState.IsValid)
                {
                    return View("HakkimizdaGuncelle", GelenVeri);
                }
                if (GelenVeri.fotoFile != null)
                {
                    GelenVeri.foto = Seo.DosyaAdiDuzenle(GelenVeri.fotoFile.FileName);
                    GelenVeri.fotoFile.SaveAs(Path.Combine(Server.MapPath("~/Content/img"),Path.GetFileName(GelenVeri.foto)));
                }


                db.Entry(GuncellenecekVeri).CurrentValues.SetValues(GelenVeri);
                db.SaveChanges();
                TempData["hakkimdaGuncelle"] = "";
                return RedirectToAction("index","hakkimizda");
            }
        }
    }
}