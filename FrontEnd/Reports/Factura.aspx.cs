using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BackEnd.Entities;
using BackEnd.DAL;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using FrontEnd.Models;

namespace FrontEnd.Reports
{
    public partial class ReporteFactura : System.Web.UI.Page
    {
        private BDContext context;
        protected void Page_Load(object sender, EventArgs e)
        {
           // contruirReporte();
        }

        void contruirReporte()
        {

            ///indicar la ruta del reporte
            ///~=indica la raíz del sitio web y que ahí busque la carpeta formularios
            string rutaReporte = "~/Reports/ReporteFactura.rdlc";
            ///construir la ruta física
            string rutaServidor = Server.MapPath(rutaReporte);
            ///Validar que la ruta física exista
            if (!File.Exists(rutaServidor))
            {
                this.Label1.Text =
                    "El reporte seleccionado no existe";
                return;
            }
            else
            {
                ReportViewer1.LocalReport.ReportPath = rutaServidor;
                var infoFuenteDatos = this.ReportViewer1.LocalReport.GetDataSourceNames();
                ///ReportViewer1 los datos de la fuente de datos
                ReportViewer1.LocalReport.DataSources.Clear();
                ///obtener los datos del reporte
                List<sp_FacturaComida_Result> datosReporte =
                    this.retornaDatosReporte();
                ///crear la fuente de datos
                ReportDataSource fuenteDatos = new ReportDataSource();
                fuenteDatos.Name = infoFuenteDatos[0];
                fuenteDatos.Value = datosReporte;
                // agregar la fuente de datos al reporte
                this.ReportViewer1.LocalReport.DataSources.Add(fuenteDatos);

                /// mostrar los datos en el reporte
                this.ReportViewer1.LocalReport.Refresh();
            }
        }
        /// <summary>
        /// Función que retorna la fuente de datos a mostrar en el reporte
        /// </summary>
        /// <param name="pPrimerApellido"></param>
        /// <param name="pNombre"></param>
        /// <returns></returns>
        ///    CompraViewModel lista = Session["Entradas"] as CompraViewModel;
      
        List<sp_FacturaComida_Result> retornaDatosReporte()
        {
            
            User userViewModel = Session["Usuario_Compra"] as User;
          
            List<sp_FacturaComida_Result> resultado = new List<sp_FacturaComida_Result>();
            using (context = new BDContext())
            {
                resultado = context.sp_FacturaComida(userViewModel.nombre,"1").ToList();
            }
            Session.Remove("Usuario_Compra");
            Session.Remove("Entradas");
            return resultado;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            contruirReporte();
        }
    }
}