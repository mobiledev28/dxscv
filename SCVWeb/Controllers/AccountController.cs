using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCVWeb.Models;
using System.Web.Security;
using SCVData;

namespace SCVWeb.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountViewModel.LoginModel model, string test)
        {

            SCV_Cuenta usrLogged = AccountDB.UserExist(model.User, model.Password);

            //bool userExist = AccountDB2.UserExist(model.User, model.Password);

            if (usrLogged != null)
            {
                //Add user info to a session variable
                SessionUserViewModel suvm = new SessionUserViewModel();
                suvm.UserName = model.User;
                suvm.Email = model.User;
                suvm.CuentaId = usrLogged.CuentaId;

                Session["_UserLogged"] = suvm;

                FormsAuthentication.SetAuthCookie(model.User, false);
                //FormsAuthentication.SetAuthCookie(model.User, model.Password);
                UserActivity ua = new UserActivity
                {
                    UserActivityDate = DateTime.Now,
                    UserActivityTypeId = 1,
                    UserId = model.User
                };

                AccountDB.SaveUserActivity(ua);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Usuario y/o Contraseña incorrectos.");
            }
            
            return View(model);

            }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Create()
        {
            SessionUserViewModel currentUser = new SessionUserViewModel();
            currentUser = (SessionUserViewModel)Session["_UserLogged"];
            ViewBag.CurrentUser = currentUser.UserName;
            return View();
        }

        [HttpPost]
        public JsonResult ObtieneCuentas(DataTableViewModel props, FormCollection fc)
        {
            try
            {
                SCVCuentaViewModel cvm = new SCVCuentaViewModel();
                List<SCV_Cuenta> cuentasList = new List<SCV_Cuenta>();

                cuentasList = AccountDB.ObtieneCuentasDB();

                List<SCVCuentaViewModel> cvmList = new List<SCVCuentaViewModel>();

                foreach (SCV_Cuenta cta in cuentasList)
                {
                    cvm = new SCVCuentaViewModel
                    {
                        CuentaId = cta.CuentaId,
                        UserName = cta.UserName,
                        Password = cta.Password,
                        FechaAlta = string.Format("{0:d}", cta.FechaAlta),//(cta.FechaAlta != null) ? string.Format("{0:d}", cta.FechaAlta) : string.Empty,
                    };
                    cvmList.Add(cvm);
                }

                //foreach (MTL_Maps2_Result res in data.ToList())
                //{
                //    mdvm = new MarkerDataDetailsViewModel
                //    {
                //        CustNum = res.CustNum,
                //        Cliente = res.Cliente,
                //        ClientName = res.ClientName,
                //        QuoteNum = res.OrderNum,
                //        QuoteLine = res.OrderLine,
                //        PartNum = res.PartNum,
                //        FechaOrden = res.FechaOrden,
                //        FechaServicio = res.FechaServicio,
                //        Status = res.Status,
                //        SalesRepName = res.SalesRepName,
                //        SalesRepCode = res.SalesRepCode,
                //        Tecnico = res.Tecnico,
                //        IDEquipo = res.IDEquipo,
                //        DescEquipo = res.DescEquipo,
                //        Marca = res.Marca,
                //        Modelo = res.Modelo,
                //        NoSerie = res.NoSerie,
                //        MontoLinea = res.MontoLinea != null ? String.Format("{0:c}", res.MontoLinea) : String.Format("{0:c}", 0),
                //        MontoOrden = res.MontoOrden != null ? String.Format("{0:c}", res.MontoOrden) : String.Format("{0:c}", 0)

                //    };
                //    markerDetailList.Add(mdvm);
                //}

                //IOrderedQueryable<Relationship> rels = null;
                List<SCVCuentaViewModel> filteredCtas = new List<SCVCuentaViewModel>();
                if (!String.IsNullOrEmpty(props.sSearch))
                {
                    filteredCtas = cvmList.Where(ct => ct.UserName.Contains(props.sSearch.ToUpper()) ||
                        ct.Password.ToString().Contains(props.sSearch)).ToList();
                }
                else
                {
                    filteredCtas = cvmList;
                }

                //lets sort
                List<SCVCuentaViewModel> ctaListSort = new List<SCVCuentaViewModel>();
                if (props.iDisplayLength > 0)
                    ctaListSort = filteredCtas.Skip(props.iDisplayStart).Take(props.iDisplayLength).ToList();
                else
                    ctaListSort = filteredCtas.ToList();

                var cuentasFilteredCount = this.CuentasFielteredCount(cvmList, props.sSearch);

                var outJson = new
                {
                    success = "yes",
                    iTotalRecords = cvmList.Count(),
                    iTotalDisplayRecords = cuentasFilteredCount,
                    data = ctaListSort != null ? ctaListSort : null
                };

                return Json(outJson, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                var outJsonErr = new
                {
                    success = "no",
                    iTotalRecords = 0,
                    iTotalDisplayRecords = 0,
                    data = new List<SCV_Cuenta>(),
                    errDesc = ex.Message.ToString()
                };
                return Json(outJsonErr, JsonRequestBehavior.AllowGet);
            }

        }

        //public string ObtieneNombreUsuario(long usuarioId)
        //{
        //    try
        //    {
        //        string nombreusr = string.Empty;
        //        nombreusr = AccountDB.ObtieneNombreUsuarioDB(usuarioId);
                
        //        return nombreusr;
        //    }
        //    catch (Exception ex)
        //    {
        //        string err = ex.Message.ToString();
        //        return string.Empty;
        //    }
        //}



        public int CuentasFielteredCount(List<SCVCuentaViewModel> cuentasList, string sSearch)
        {
            var records = 0;

            if (!String.IsNullOrEmpty(sSearch))
            {
                records = cuentasList.Count(ct => ct.UserName.Contains(sSearch.ToUpper()));
            }
            else
            {
                records = cuentasList.Count();
            }

            return records;

        }

        [HttpGet]
        public JsonResult GuardaDatosCuenta(string username, string password)
        {
            SessionUserViewModel suvm = new SessionUserViewModel();
            //Get Information from user logged
            suvm = Session["_UserLogged"] != null ? (SessionUserViewModel)Session["_UserLogged"] : null;
            
            try {
                //Call method to save information into the data base
                //bool isSaved = AccountDB.InsertaCuenta(username, password, suvm.CuentaId);
                //Save user activity
                //UserActivity ua = new UserActivity
                //{
                //    UserActivityDate = DateTime.Now,
                //    UserActivityTypeId = 2,
                //    UserId = suvm.UserName
                //};

                //this.db.UserActivity.Add(ua);
                //this.mtlDB.SaveChanges();

                var outJson = new
                {
                    success = "yes",
                    //data = markersList != null ? markersList : null
                };

                return Json(outJson, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                var outJsonErr = new
                {
                    failure = ex.Message,
                    success = "no",
                    //data = new List<MarkerDataViewModel>()
                };
                return Json(outJsonErr, JsonRequestBehavior.AllowGet);
            }

        }


    }
}
