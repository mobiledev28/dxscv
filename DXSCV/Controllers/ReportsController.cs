using DXSCV.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXSCV.Controllers
{
    public class ReportsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RptVehiculos()
        {
            return View(new RptVehiculo());
        }

        public ActionResult OrdenMtto(){
            return View(new OrdenMtto());
        }
    }
}
