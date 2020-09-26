using AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Areas.Admin.Controllers
{
    public class IletisimController : Controller
    {
        [Authorize]
        // GET: Admin/Iletisim
        public ActionResult Index()
        {
            using (site2020Entities db = new site2020Entities())
            {
                var model = db.iletisim.First();
                return View(model);
            }
        }
    }
}