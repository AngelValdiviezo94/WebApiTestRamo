using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using WebApiRamo.Metodos;
using WebApiRamo.Utilities;


namespace WebApiRamo.Controllers
{
    [RoutePrefix("api/Producto")]
    public class ProductoController : ApiController
    {
        Producto MetCliente = new Producto();
        private ConversionClase metodoGenerico = new ConversionClase();

        [HttpGet]
        [Route("ConsultaProductos")]
        public List<cl_Producto> Obten_Clientes()
        {
            List<cl_Producto> LstClientes = new List<cl_Producto>();
            cl_Producto clCanton = new cl_Producto();
            DataTable dataTable = new DataTable();
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            try
            {
                dataTable = this.MetCliente.ConsultaProductos();
                if (dataTable.Rows.Count <= 0)
                {
                    respuestaModelo.ProcesoExitoso = false;
                }
                else
                {
                    respuestaModelo.ProcesoExitoso = true;
                    ConversionClase ObjConversionClase = new ConversionClase();
                    LstClientes = ObjConversionClase.ListaProductos(dataTable);
                }
            }
            catch (Exception ex)
            {
                LstClientes = null;
            }
            return LstClientes;
        }

        [HttpGet]
        [Route("ConsultaProductoById")]
        public cl_Producto ConsultaProductoById(int Id)
        {
            //List<cl_Producto> LstClientes = new List<cl_Producto>();
            cl_Producto ClProducto = new cl_Producto();
            DataTable dataTable = new DataTable();
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            try
            {
                dataTable = this.MetCliente.ConsultaProductoById(Id.ToString());
                if (dataTable.Rows.Count <= 0)
                {
                    respuestaModelo.ProcesoExitoso = false;
                }
                else
                {
                    respuestaModelo.ProcesoExitoso = true;
                    ConversionClase ObjConversionClase = new ConversionClase();
                    ClProducto = ObjConversionClase.ObjProducto(dataTable);
                }
            }
            catch (Exception ex)
            {
                ClProducto = null;
            }
            return ClProducto;
        }

        [HttpPost]
        [Route("GuardaProductos")]
        public int GuardaProducto(List<cl_Producto> lstClientes)
        {
            string empty = string.Empty;
            string str = string.Empty;
            int num = 0;
            try
            {
                num = this.MetCliente.GuardaListaProductos(lstClientes, ref str, ref empty);
            }
            catch (Exception exception)
            {
                num = -1;
            }
            return num;
        }

        [HttpPost]
        [Route("ModificaProductos")]
        public RespuestaModelo ModificaProducto(cl_Producto objGDA)
        {
            string empty = string.Empty;
            string str = string.Empty;
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            int num = 0;
            try
            {
                num = this.MetCliente.ModificaProducto(objGDA, ref str, ref empty);
                respuestaModelo.ProcesoExitoso = true;
                respuestaModelo.Respuesta.Add(num);
            }
            catch (Exception exception)
            {
                this.metodoGenerico.LlenaRespuestaModeloError(exception);
            }
            return respuestaModelo;
        }

        [HttpGet]
        [Route("EliminaProducto")]
        public RespuestaModelo EliminaProducto(int idProducto)
        {
            string empty = string.Empty;
            string str = string.Empty;
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            int num = 0;
            try
            {
                num = this.MetCliente.EliminaProducto(idProducto, ref str, ref empty);
                respuestaModelo.ProcesoExitoso = true;
                respuestaModelo.Respuesta.Add(num);
            }
            catch (Exception exception)
            {
                this.metodoGenerico.LlenaRespuestaModeloError(exception);
            }
            return respuestaModelo;
        }

    }
}
