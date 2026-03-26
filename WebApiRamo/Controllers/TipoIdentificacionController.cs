using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using WebApiRamo.Metodos;
using WebApiRamo.Utilities;

namespace WebApiRamo.Controllers
{
    [RoutePrefix("api/TipoIdentificacion")]
    public class TipoIdentificacionController : ApiController
    {
        TipoIdentificacion MetCliente = new TipoIdentificacion();
        private ConversionClase metodoGenerico = new ConversionClase();

        [HttpGet]
        [Route("ConsultaTipoIdentificacion")]
        public List<cl_Tipo_Identificacion> ConsultaTipoIdentificacion()
        {
            List<cl_Tipo_Identificacion> LstClientes = new List<cl_Tipo_Identificacion>();
            cl_Tipo_Identificacion clCanton = new cl_Tipo_Identificacion();
            DataTable dataTable = new DataTable();
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            try
            {
                dataTable = this.MetCliente.ConsultaTipoIdentificacion();
                if (dataTable.Rows.Count <= 0)
                {
                    respuestaModelo.ProcesoExitoso = false;
                }
                else
                {
                    respuestaModelo.ProcesoExitoso = true;
                    ConversionClase ObjConversionClase = new ConversionClase();
                    LstClientes = ObjConversionClase.ListaTipoIdentificacion(dataTable);
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
