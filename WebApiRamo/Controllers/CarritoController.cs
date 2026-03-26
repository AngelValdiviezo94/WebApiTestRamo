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

        [HttpGet]
        [Route("ConsultaCarrito")]
        public cl_CarritoCab ConsultaCarrito(int id)
        {
            List<cl_CarritoCab> LstClientes = new List<cl_CarritoCab>();
            cl_CarritoCab CarritoCab = new cl_CarritoCab();
            DataTable dataTable = new DataTable();
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            try
            {
                dataTable = this.MetCliente.ConsultaCarrito(id);
                if (dataTable.Rows.Count <= 0)
                {
                    respuestaModelo.ProcesoExitoso = false;
                }
                else
                {
                    respuestaModelo.ProcesoExitoso = true;
                    ConversionClase ObjConversionClase = new ConversionClase();
                    CarritoCab = ObjConversionClase.ListaCarrito(dataTable);
                }
            }
            catch (Exception ex)
            {
                CarritoCab = null;
            }
            return CarritoCab;
        }
        
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
