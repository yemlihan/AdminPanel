using AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.anasayfa.ToList();
                return View(model);
            }
        }
       
        public ActionResult YeniSayfa(int id)
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.anasayfa.Where(x =>x.id == id).FirstOrDefault();
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }


        }

        [Route("Hakkımızda")]
        public ActionResult Hakkimizda()
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.hakkimizda.Find(1);
                return View(model);
            }
            
        }
        [Route("Ürünler")]
        public ActionResult Urunler()
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.urunler.Where(x=> x.aktif == true).OrderBy(x=> x.sira).ToList();

                return View(model);
            }
           
        }

        [Route("urun/{id}/{baslik}")]
        public ActionResult UrunDetay(int id)
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.urunler.Where(x => x.aktif == true && x.id == id).FirstOrDefault();
                if (model==null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }

           
        }

        [Route("İletişim")]
       
        public ActionResult İletisim()
        {
            return View();
          
        }

       

      
    }
}