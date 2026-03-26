using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using WebApiRamo.Metodos;
using WebApiRamo.Utilities;

namespace WebApiRamo.Controllers
{
    [RoutePrefix("api/EstadoCivil")]
    public class EstadoCivilController : ApiController
    {
        EstadoCivil MetCliente = new EstadoCivil();
        private ConversionClase metodoGenerico = new ConversionClase();

        [HttpGet]
        [Route("ConsultaEstadoCivil")]
        public List<cl_EstadoCivil> ConsultaEstadoCivil()
        {
            List<cl_EstadoCivil> LstClientes = new List<cl_EstadoCivil>();
            cl_EstadoCivil clCanton = new cl_EstadoCivil();
            DataTable dataTable = new DataTable();
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            try
            {
                dataTable = this.MetCliente.ConsultaEstadoCivil();
                if (dataTable.Rows.Count <= 0)
                {
                    respuestaModelo.ProcesoExitoso = false;
                }
                else
                {
                    respuestaModelo.ProcesoExitoso = true;
                    ConversionClase ObjConversionClase = new ConversionClase();
                    LstClientes = ObjConversionClase.ListaEstadoCivil(dataTable);
                }
            }
            catch (Exception ex)
            {
                LstClientes = null;
            }
            return LstClientes;
        }

    }
}
