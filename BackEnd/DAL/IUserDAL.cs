using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IUserDAL
    {

        bool insertar(int idRole, string login);
        bool insertar(string roleName, string login);
        User getUser(string userName);
        User getUser(string userName, string password);
        User getUser(int EmpleadoId);
        User get(int id);
        List<User> getAll();
        bool isUserInRole(string userName, string roleName);
        string[] gerRolesForUser(string userName);
        List<User> getUsuariosRole(string roleName);
        List<Role> listarRoles();
        bool eliminar(string idRole, int idUsuario);
        User ObtenerPorID(int id);


    }
}
