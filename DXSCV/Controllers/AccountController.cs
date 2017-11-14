using DXSCV.Models;
using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DXSCV.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

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
                suvm.TipoUsuarioId = usrLogged.TipoUsuarioId;
                suvm.EmpresaId = usrLogged.EmpresaId;
                suvm.IsHerrMty = usrLogged.IsHerrMty;
                suvm.IsMetalinspec = usrLogged.IsMetalinspec;
                suvm.IsMetalinspecLab = usrLogged.IsMetalinspecLab;
                suvm.IsMetroLab = usrLogged.IsMetroLab;


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

                return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Login", "Account");
        }

    }
}
