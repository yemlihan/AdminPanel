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
    public class UrunlerController : Controller
    {
        [Authorize]
        // GET: Admin/Urunler
        public ActionResult Index()
        {

            using (site2020Entities db = new site2020Entities())
            {
                var model = db.urunler.ToList();

                return View(model);
            }
        }

        public ActionResult Yeni()
        {
            var model = new urunler();
            return View("urunForm",model);
        }

        public ActionResult Guncelle(int id)
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.urunler.Find(id);
                
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View("urunForm",model);
            }
        }

        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(urunler gelenUrun)
        {

            if (!ModelState.IsValid)
            {
                return View("urunForm",gelenUrun);
            }

            using (site2020Entities db = new site2020Entities())
            {
                if (gelenUrun.id == 0)//yeni ürün
                {
                    if (gelenUrun.fotoFile == null)
                    {
                        ViewBag.HataFoto = "Lütfen Fotograf Yükleyiniz.";
                        return View("urunForm", gelenUrun);
                    }
                    string fotoAdi = Seo.DosyaAdiDuzenle(gelenUrun.fotoFile.FileName);
                    gelenUrun.foto = fotoAdi;
                    db.urunler.Add(gelenUrun);
                    gelenUrun.fotoFile.SaveAs(Path.Combine(Server.MapPath("~/Content/img"), Path.GetFileName(gelenUrun.foto)));
                    TempData["urun"] = "Ürün Başarılı bir şekilde eklendi.";
                }
                else//guncelleme
                {
                    var guncellenecekVeri = db.urunler.Find(gelenUrun.id);
                    if (gelenUrun.fotoFile != null)
                    {
                        string fotoAdi = Seo.DosyaAdiDuzenle(gelenUrun.fotoFile.FileName);
                        gelenUrun.foto = fotoAdi;
                        gelenUrun.fotoFile.SaveAs(Path.Combine(Server.MapPath("~/Content/img"), Path.GetFileName(gelenUrun.foto)));

                    }

                    db.Entry(guncellenecekVeri).CurrentValues.SetValues(gelenUrun);
                    TempData["urun"] = "Ürün başarılı bir şekilde güncellendi."; 
                }
                db.SaveChanges();

                return RedirectToAction("index");
            }
        }

        public ActionResult Sil(int id)
        {
            using (site2020Entities db = new site2020Entities())
            {
                var silinecekUrun = db.urunler.Find(id);
                if (silinecekUrun == null)
                {
                    return HttpNotFound();
                }

                db.urunler.Remove(silinecekUrun);
                db.SaveChanges();
                TempData["urun"] = "Ürün Başarılı bir şekilde silindi.";
                return RedirectToAction("index");
            }
        }
    }
}