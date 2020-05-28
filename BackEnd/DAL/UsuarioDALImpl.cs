using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;


namespace BackEnd.DAL.Usuarios
{
    public class UsuarioDALImpl : IUsuarioDAL
    {
        private BDContext context;

        public void AddUsuario(Users user)
        {
            using (context = new BDContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void DeleteUsuario(int id)
        {
            using (context = new BDContext())
            {
                Users user;
                user = (from c in context.Users
                            where c.UserId == id
                            select c).FirstOrDefault();
                context.Users.Remove(user);
                context.SaveChanges();
            }
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Users GetUsuario(string nombre)
        {
            Users result;
            using (context = new BDContext())
            {
                result = (from u in context.Users
                          where u.nombre == nombre
                          select u).FirstOrDefault();
            }
            return result;
        }

        public Users GetUsuarioById(int id)
        {
            Users result;
            using (context = new BDContext())
            {
                result = (from u in context.Users
                          where u.UserId == id
                          select u).FirstOrDefault();
            }
            return result;
        }

       
        public List<Users> GetUsuarios()
        {
            List<Users> result;
            using (context = new BDContext())
            {
                result = (from u in context.Users
                          select u).ToList();
            }
            return result;
        }

        public Users InicioSesion(string nombre)
        {
            try {

                Users result;
                using (context = new BDContext())
                {
                    result = (from u in context.Users
                              where u.UserName == nombre 
                              select u).FirstOrDefault();
                }
                return result;

            } catch(Exception ex)
             {
                throw new Exception("Error:"+ex); ;
             }
            
        }

        public void UpdateUsuario(Users user)
        {
            using (context = new BDContext())
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
