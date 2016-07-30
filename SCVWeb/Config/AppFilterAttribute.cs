﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using HEBADomicilio.DAO.Common;
//using HEBADomicilio.DAO.LogicData;
//using HEBADomicilio.DAO.ViewModels;
//using Sismex.WebMVC;
//using Sismex.WebMVC.Helpers;
using SCVWeb.Models;

namespace SCVWeb.Config
{
    public class AppFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextBase httpContext = filterContext.HttpContext;
            if (System.Web.HttpContext.Current.Session != null)
            {

                if (httpContext.User.Identity.IsAuthenticated)
                {
                    if (httpContext.Session.Contents["_UserLogged"] != null)
                    {
                        SessionUserViewModel sUsuario = (SessionUserViewModel)httpContext.Session["_UserLogged"];
                        string cAccion = filterContext.ActionDescriptor.ActionName;
                        string cControlador = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                    } else{
                        filterContext.Result = new RedirectResult("~/Account/Login");
                    }
                }
                else
                {
                    //httpContext.Response.Redirect("~/Home/Index", true);
                    filterContext.Result = new RedirectResult("~/Account/Login");
                }
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}