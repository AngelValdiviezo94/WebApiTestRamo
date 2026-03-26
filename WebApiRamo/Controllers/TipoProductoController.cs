using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using WebApiRamo.Metodos;
using WebApiRamo.Utilities;

namespace WebApiRamo.Controllers
{
    [RoutePrefix("api/TipoProducto")]
    public class TipoProductoController : ApiController
    {
        TipoProducto MetCliente = new TipoProducto();
        private ConversionClase metodoGenerico = new ConversionClase();

        [HttpGet]
        [Route("ConsultaTipoProductos")]
        public List<cl_Tipo_Producto> ConsultaTipoProductos()
        {
            List<cl_Tipo_Producto> LstClientes = new List<cl_Tipo_Producto>();
            cl_Tipo_Producto clCanton = new cl_Tipo_Producto();
            DataTable dataTable = new DataTable();
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            try
            {
                dataTable = this.MetCliente.ConsultaTipoProductos();
                if (dataTable.Rows.Count <= 0)
                {
                    respuestaModelo.ProcesoExitoso = false;
                }
                else
                {
                    respuestaModelo.ProcesoExitoso = true;
                    ConversionClase ObjConversionClase = new ConversionClase();
                    LstClientes = ObjConversionClase.ListaTipoProducto(dataTable);
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
