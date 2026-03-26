using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using WebApiRamo.Metodos;
using WebApiRamo.Utilities;

namespace WebApiRamo.Controllers
{
    [RoutePrefix("api/Carrito")]
    public class CarritoController : ApiController
    {
        Carrito MetCliente = new Carrito();
        private ConversionClase metodoGenerico = new ConversionClase();

        /*
        [HttpGet]
        [Route("ConsultaCarrito")]
        public List<cl_Carrito> ConsultaCarrito()
        {
            List<cl_Carrito> LstClientes = new List<cl_Carrito>();
            cl_Carrito clCanton = new cl_Carrito();
            DataTable dataTable = new DataTable();
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            try
            {
                dataTable = this.MetCliente.ConsultaCarrito();
                if (dataTable.Rows.Count <= 0)
                {
                    respuestaModelo.ProcesoExitoso = false;
                }
                else
                {
                    respuestaModelo.ProcesoExitoso = true;
                    ConversionClase ObjConversionClase = new ConversionClase();
                    LstClientes = ObjConversionClase.ListaCarrito(dataTable);
                }
            }
            catch (Exception ex)
            {
                LstClientes = null;
            }
            return LstClientes;
        }
        */

        [HttpPost]
        [Route("GuardaCarrito")]
        public int GuardaProducto(cl_CarritoCab lstClientes)
        {
            string empty = string.Empty;
            string str = string.Empty;
            int num = 0;
            try
            {
                num = this.MetCliente.GuardaListaCarrito(lstClientes, ref str, ref empty);
            }
            catch (Exception exception)
            {
                num = -1;
            }
            return num;
        }


    }
}
