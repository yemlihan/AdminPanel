using AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminPanel.Areas.Admin.Controllers
{
    
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alogin(kullanicilar kullaniciFormu , string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View("index",kullaniciFormu);
            }

            using (site2020Entities db = new site2020Entities())
            {
                var kullaniciVarmi = db.kullanicilar.FirstOrDefault(
                    x => x.kad == kullaniciFormu.kad && x.sifre == kullaniciFormu.sifre);

                if (kullaniciVarmi != null)
                {
                    FormsAuthentication.SetAuthCookie(kullaniciVarmi.kad, kullaniciFormu.BeniHatirla);

                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return RedirectToAction(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("/index", "anasayfa");
                    }
                    

                   
                }

                ViewBag.Hata = "Kullanıcı adı veya Şifre Hatalı!!! ";

                return View("index");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("index");
        }
    }
}