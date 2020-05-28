using BackEnd.DAL;
using BackEnd.DAL.Usuarios;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        
         public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userModel)
        {
             UsuarioDALImpl usuarioDAL = new UsuarioDALImpl();
            var userDetails = usuarioDAL.InicioSesion(userModel.UserName);

            if (userDetails == null)
            {
                userModel.LoginErrorMessage = "Nombre de Usuario o Contraseña Incorrectos";
                return View("Index", userModel);
            }
            else
            {
                if (userModel.UserName == userDetails.UserName && userModel.Contrasena == userDetails.Password)
                {
                    Session["Usuario"] = userDetails;



                    return RedirectToAction("Index", "Proyecciones");
                }
                else 
                {

                    return RedirectToAction("Index", "Login");
                }

            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
