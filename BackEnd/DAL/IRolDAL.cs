using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IRolDAL
    {
        void AddRol(Roles rol);
        void UpdateRol(Roles rol);
        void DeleteRol(int id);
        Roles GetRolById(int id);
        List<Roles> GetRol();
    }
}
