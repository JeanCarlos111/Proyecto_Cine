using BackEnd.DAL;
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

            List<User> user;
            using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(new BDContext()))
            {
                user = unidad.genericDAL.GetAll().ToList();
            }
            List<UserViewModel> userVM = new List<UserViewModel>();

            UserViewModel userViewModel;
            foreach (var item in user)
            {
                userViewModel = new UserViewModel
                {
                    UserViewModelId = item.UserId,
                    nombre = item.nombre,
                    apellidos = item.apellidos,
                    Password = item.Password,
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
            string mensaje = "";
            try
            {
                mensaje = "Agregado con exito";
                User user = new User()
                {
                    UserId = userViewModel.UserViewModelId,
                    nombre = userViewModel.nombre,
                    apellidos = userViewModel.apellidos,
                    Password = userViewModel.Password,
                    mail = userViewModel.mail,
                    UserName = userViewModel.UserName,
                    phone= userViewModel.phone
                };

                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(new BDContext()))
                {
                    unidad.genericDAL.Add(user);
                    unidad.Complete();
                }
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
            UserViewModel userViewModel;
            User user;
            using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(new BDContext()))
            {
                user = unidad.genericDAL.Get(id);
            }
            userViewModel = new UserViewModel()
            {
                UserViewModelId = user.UserId,
                nombre = user.nombre,
                apellidos = user.apellidos,
                Password = user.Password,
                mail = user.mail,
                UserName = user.UserName,
                phone = user.phone
            };
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            string mensaje = "";
            try
            {
                mensaje = "Modificado con exito";
                User user = new User()
                {
                    UserId = userViewModel.UserViewModelId,
                    nombre = userViewModel.nombre,
                    apellidos = userViewModel.apellidos,
                    Password = userViewModel.Password,
                    mail = userViewModel.mail,
                    UserName = userViewModel.UserName,
                    phone = userViewModel.phone
                };

                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(new BDContext()))
                {
                    unidad.genericDAL.Update(user);
                    unidad.Complete();
                }
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
            string mensaje = "";
            try
            {
                mensaje = "Eliminado con exito";
                User user;
                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(new BDContext()))
                {
                    user = unidad.genericDAL.Get(id);
                    unidad.genericDAL.Remove(user);
                    unidad.Complete();
                }
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
            UserViewModel userViewModel;
            User user;

            using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(new BDContext()))
            {
                user = unidad.genericDAL.Get(id);
            }
            userViewModel = new UserViewModel()
            {
                UserViewModelId = user.UserId,
                nombre = user.nombre,
                apellidos = user.apellidos,
                Password = user.Password,
                mail = user.mail,
                UserName = user.UserName,
                phone = user.phone
            };
            return View(userViewModel);
        }
    }
}