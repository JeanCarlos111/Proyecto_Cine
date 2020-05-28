using BackEnd.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Usuarios
{
    public interface IUsuarioDAL : IDisposable
    {
        void AddUsuario(Users user);
        void UpdateUsuario(Users user);
        void DeleteUsuario(int id);

        Users GetUsuario(string name);
        Users GetUsuarioById(int id);
        List<Users> GetUsuarios();
        Users InicioSesion(string name_user);
    }
}
