using AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Areas.Admin.Controllers
{
    public class KullanicilarController : Controller
    {

        [Authorize(Roles ="Yönetici")]
        // GET: Admin/Kullanicilar
        public ActionResult Index()
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.kullanicilar.ToList();
                return View(model);
            }
        }
        public ActionResult Yeni()
        {
            var model = new kullanicilar();
            return View("kullaniciForm",model);
        }
        public ActionResult Guncelle(int id)
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.kullanicilar.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View("kullaniciForm",model);
            }
        }
        [ValidateAntiForgeryToken]
       
        public ActionResult Kaydet(kullanicilar gelenKullanici)
        {
            if (!ModelState.IsValid)
            {
                return View("kullaniciForm",gelenKullanici);
            }

            using (site2020Entities db = new site2020Entities())
            {
                if (gelenKullanici.id == 0 )
                {
                    db.kullanicilar.Add(gelenKullanici);
                    TempData["kullanici"] = "Kullanıcı başarılı bir şekilde eklendi.";                }
                else
                {
                    var guncellenecekVeri = db.kullanicilar.Find(gelenKullanici.id);
                    db.Entry(guncellenecekVeri).CurrentValues.SetValues(gelenKullanici);
                    TempData["kullanici"] = "Kullanıcı başarılı bir şekilde güncellendi.";
                }
                db.SaveChanges();
                return RedirectToAction("index");
            }
        }
        public ActionResult Sil(int id)
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.kullanicilar.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                db.kullanicilar.Remove(model);
                db.SaveChanges();
                TempData["kullanici"] = "Kullanıcı silme işlemi başarılı.";
                return RedirectToAction("index");
            }
        }
    }
}