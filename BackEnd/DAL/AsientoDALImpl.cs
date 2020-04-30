using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class AsientoDALImpl : DALGenericoImpl<Asiento>, IAsientoDAL
    {
        private UnidadDeTrabajo<Asiento> unidad;
        private BDContext context;

        public AsientoDALImpl()
            : base(new BDContext())

        {

        }


        public AsientoDALImpl(BDContext context)
            : base(context)
        {
            this.context = context;
        }

        public List<Asiento> GetAsientosId(int? id)
        {
            try
            {
                List<Asiento> lista;
                using (context = new BDContext())
                {

                    lista = (from c in context.Asientoes
                             where c.id_sala == id
                             select c).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}


    
    
