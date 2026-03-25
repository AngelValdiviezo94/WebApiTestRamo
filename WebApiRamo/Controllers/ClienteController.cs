
using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using WebApiRamo.Metodos;
using WebApiRamo.Utilities;

namespace WebApiRamo.Controllers
{
    [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {
        Cliente MetCliente = new Cliente();
        private ConversionClase metodoGenerico = new ConversionClase();

        [HttpGet]
        [Route("ConsultaClientes")]
        public List<cl_Cliente> Obten_Clientes()
        {
            List<cl_Cliente> LstClientes = new List<cl_Cliente>();
            cl_Cliente clCanton = new cl_Cliente();
            DataTable dataTable = new DataTable();
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            try
            {
                dataTable = this.MetCliente.ConsultaClientes();
                if (dataTable.Rows.Count <= 0)
                {
                    respuestaModelo.ProcesoExitoso = false;
                }
                else
                {
                    respuestaModelo.ProcesoExitoso = true;
                    ConversionClase ObjConversionClase = new ConversionClase();
                    LstClientes = ObjConversionClase.ListaCliente(dataTable);
                }
            }
            catch (Exception ex)
            {
                LstClientes = null;
            }
            return LstClientes;
        }

        [HttpPost]
        [Route("GuardaCliente")]
        public int GuardaCliente(List<cl_Cliente> lstClientes)
        {
            string empty = string.Empty;
            string str = string.Empty;
            int num = 0;
            try
            {
                num = this.MetCliente.GuardaListaClientes(lstClientes, ref str, ref empty);
            }
            catch (Exception exception)
            {
                num = -1;
            }
            return num;
        }

        [HttpPost]
        [Route("ModificaCliente")]
        public RespuestaModelo ModificaCliente(cl_Cliente objGDA)
        {
            string empty = string.Empty;
            string str = string.Empty;
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            int num = 0;
            try
            {
                num = this.MetCliente.ModificaCliente(objGDA, ref str, ref empty);
                respuestaModelo.ProcesoExitoso = true;
                respuestaModelo.Respuesta.Add(num);
            }
            catch (Exception exception)
            {
                this.metodoGenerico.LlenaRespuestaModeloError(exception);
            }
            return respuestaModelo;
        }

        [HttpPost]
        [Route("EliminaCliente")]
        public RespuestaModelo EliminaCliente(int idCliente)
        {
            string empty = string.Empty;
            string str = string.Empty;
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            int num = 0;
            try
            {
                num = this.MetCliente.EliminaCliente(idCliente, ref str, ref empty);
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
