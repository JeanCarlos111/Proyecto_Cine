using BackEnd.DAL;
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
        private IUserDAL userDAL;

        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(UserViewModel userModel)
        {
            userDAL = new UserDALImpl();
            var userDetails = userDAL.getUser(userModel.UserName, userModel.Password);

            if (userDetails == null)
            {
                userModel.LoginErrorMessage = "Nombre de Usuario o Contraseña Incorrectos";
                return View("Index", userModel);
            }
            else
            {
                //Against AD
                //http://www.benramey.com/2014/10/20/active-directory-authentication-in-asp-net-mvc-5-with-forms-authentication-and-group-based-authorization/
                //http://www.beansoftware.com/ASP.NET-Tutorials/Forms-Authentication-Active-Directory.aspx
                Session["userID"] = userDetails.UserId;
                Session["userName"] = userDetails.UserName;
                var authTicket = new FormsAuthenticationTicket(userDetails.UserName, true, 100000);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                            FormsAuthentication.Encrypt(authTicket));
                Response.Cookies.Add(cookie);
                var name = User.Identity.Name; // line 4
                return RedirectToAction("Index", "Home");
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
