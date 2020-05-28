using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;
using BackEnd.DAL;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AsientoDALImpl asientoDAL = new AsientoDALImpl();
           List<Asiento> asientos = asientoDAL.GetAsientosBySala(1);
            
            for (int i = 0; i < asientos.Count; i++)
            {
                Console.WriteLine(asientos[i].numero_asiento);
            }
        }
    }
}
