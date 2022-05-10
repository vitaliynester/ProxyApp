using ProxyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProxyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserProfileContext _db = new UserProfileContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            string apiUrl = Url.HttpRouteUrl("DefaultApi", new { controller = "Admin" });
            ViewBag.apiUrl = new Uri(Request.Url, apiUrl).AbsoluteUri.ToString();

            var items = _db.UserProfiles.ToList();

            return View(model: items);
        }
    }
}