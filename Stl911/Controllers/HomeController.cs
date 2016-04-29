using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stl911.Controllers
{
    public class HomeController : Controller
    {
        private readonly Stl911Domain.IServiceCallRepository _IServiceCallRepository;

        public HomeController(Stl911Domain.IServiceCallRepository iServiceCallRepository)
        {
            _IServiceCallRepository = iServiceCallRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // temp
        [HttpGet]
        public JsonResult GetServiceCalls()
        {
            var serv = new Stl911Domain.ServiceCallService(_IServiceCallRepository);
            return Json(serv.GetServiceCalls(), JsonRequestBehavior.AllowGet);
        }
    }
}