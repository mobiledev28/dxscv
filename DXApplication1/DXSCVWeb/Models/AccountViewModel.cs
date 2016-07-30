using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DXSCVWeb.Models
{
    public static class AccountViewModel
    {
        public class LoginModel
        {
            [Required(ErrorMessage = "El usuario es requerido")]
            [Display(Name = "Usuario")]
            public string User { get; set; }

            [Required(ErrorMessage = "El password es requerido")]
            [Display(Name = "Password")]
            public string Password { get; set; }
        }

       
    }
}