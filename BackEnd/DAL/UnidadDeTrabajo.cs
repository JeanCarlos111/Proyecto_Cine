﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly BDContext context;
        //public IDALGenerico<Queja> quejaDAL;
        //public IDALGenerico<TablaGeneral> tablaDAL;
        public IDALGenerico<T> genericDAL;


        public UnidadDeTrabajo(BDContext _context)
        {
            context = _context;
            genericDAL = new DALGenericoImpl<T>(context);
            //    quejaDAL = new DALGenericoImpl<Queja>(context);
            //    tablaDAL = new DALGenericoImpl<TablaGeneral>(context);
        }

        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
