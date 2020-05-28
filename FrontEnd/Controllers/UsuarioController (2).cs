using BackEnd.DAL;
using BackEnd.DAL.Usuarios;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        //GET: Usuario
        public ActionResult Index()
        {
            string mensaje = "";
            if (TempData["mensaje"] != null)
            {
                mensaje = TempData["mensaje"].ToString();
            }

            List<Users> user;
            UsuarioDALImpl usuarioDAL = new UsuarioDALImpl();

            user = usuarioDAL.GetUsuarios();

            List<UserViewModel> userVM = new List<UserViewModel>();

            UserViewModel userViewModel;
            foreach (var item in user)
            {
                userViewModel = new UserViewModel
                {
                    UserViewModelId = item.UserId,
                    nombre = item.nombre,
                    apellidos = item.apellidos,
                    Contrasena = item.Password,
                    mail = item.mail,
                    UserName = item.UserName,
                    phone = item.phone
                };
                userVM.Add(userViewModel);
            }
            return View(userVM);
        }

        public ActionResult Create()
        {
            UserViewModel user = new UserViewModel();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            UsuarioDALImpl usuarioDAL = new UsuarioDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Agregado con exito";
                Users user = new Users()
                {
                    UserId = userViewModel.UserViewModelId,
                    nombre = userViewModel.nombre,
                    apellidos = userViewModel.apellidos,
                    Password = userViewModel.Contrasena,
                    mail = userViewModel.mail,
                    UserName = userViewModel.UserName,
                    phone= userViewModel.phone
                };

                usuarioDAL.AddUsuario(user);
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            UsuarioDALImpl usuarioDAL = new UsuarioDALImpl();

            UserViewModel userViewModel;

            Users user;

           user= usuarioDAL.GetUsuarioById(id);
                
            
            userViewModel = new UserViewModel()
            {
                UserViewModelId = user.UserId,
                nombre = user.nombre,
                apellidos = user.apellidos,
                Contrasena = user.Password,
                mail = user.mail,
                UserName = user.UserName,
                phone = user.phone,
                id_rol = user.id_rol,
                tarjeta = user.tarjeta
                
            };
            return View(userViewModel);
        }

        public JsonResult ConsultaRoles(string [] data)
        {
            RolDALImpl rolDAL = new RolDALImpl();
            Roles rol_temporal;

            RolViewModel rolViewModel;
            if (data != null)
            {
                int data1 = int.Parse(data[0]);

                rol_temporal  = rolDAL.GetRolById(data1);


                rolViewModel = new RolViewModel
                {

                    RoleId = rol_temporal.RoleId,
                    RoleName = rol_temporal.RoleName



                };

                return Json(rolViewModel);
            }
            else
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al mapear los datos.'"));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            UsuarioDALImpl usuarioDAL = new UsuarioDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Modificado con exito";
                Users user = new Users()
                {
                    UserId = userViewModel.UserViewModelId,
                    nombre = userViewModel.nombre,
                    apellidos = userViewModel.apellidos,
                    Password = userViewModel.Contrasena,
                    mail = userViewModel.mail,
                    UserName = userViewModel.UserName,
                    phone = userViewModel.phone,
                    tarjeta = userViewModel.tarjeta,
                    id_rol = userViewModel.id_rol

                };

                usuarioDAL.UpdateUsuario(user);
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            UsuarioDALImpl usuarioDAL = new UsuarioDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Eliminado con exito";
                Users user;

                    user = usuarioDAL.GetUsuarioById(id); ;
                    usuarioDAL.DeleteUsuario(user.UserId);
                    
                
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            UsuarioDALImpl usuarioDAL = new UsuarioDALImpl();
            UserViewModel userViewModel;
            Users user;


            user = usuarioDAL.GetUsuarioById(id);
            
            userViewModel = new UserViewModel()
            {
                UserViewModelId = user.UserId,
                nombre = user.nombre,
                apellidos = user.apellidos,
                Contrasena = user.Password,
                mail = user.mail,
                UserName = user.UserName,
                phone = user.phone
            };
            return View(userViewModel);
        }
    }
}