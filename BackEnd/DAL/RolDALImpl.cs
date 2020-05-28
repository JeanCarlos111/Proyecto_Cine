using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class RolDALImpl : IRolDAL
    {
        private BDContext context;
        public void AddRol(Roles rol)
        {
            using (context = new BDContext())
            {
                context.Roles.Add(rol);
                context.SaveChanges();
            }
        }

        public void UpdateRol(Roles rol)
        {
            using (context = new BDContext())
            {
                context.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteRol(int id)
        {
            using (context = new BDContext())
            {
                Roles rol;
                rol = (from r in context.Roles
                            where r.RoleId == id
                            select r).FirstOrDefault();
                context.Roles.Remove(rol);
                context.SaveChanges();
            }
        }

        public List<Roles> GetRol()
        {
            List<Roles> result;
            using (context = new BDContext())
            {
                result = (from r in context.Roles
                         select r).ToList();

            }
            return result;
        }

        public Roles GetRolById(int id)
        {
            Roles result;
            using (context = new BDContext())
            {
                result = (from r in context.Roles
                          where r.RoleId == id
                          select r).FirstOrDefault();

            }
            return result;
        }


    }
}
