using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using WebApiRamo.Metodos;
using WebApiRamo.Utilities;

namespace WebApiRamo.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        Usuario MetCliente = new Usuario();
        private ConversionClase metodoGenerico = new ConversionClase();

        [HttpPost]
        [Route("RegistraUsuario")]
        public bool RegistrarUsuario(cl_Usuario nuevoUsuario, string passwordPlano)
        {
            // 1. Generar Salt y Hash
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(passwordPlano, salt);

            nuevoUsuario.PassWord = hashedPassword;
            nuevoUsuario.Salt = salt; // Guardarlo por si decides cambiar de algoritmo luego
            nuevoUsuario.FechaCreacion = DateTime.Now;
            nuevoUsuario.Activo = true;

            return true;
        }

        [HttpPost]
        [Route("Login")]
        public bool Login(string userName, string passwordIngresado)
        {
            bool rsp = false;
            List<cl_Cliente> LstClientes = new List<cl_Cliente>();
            cl_Usuario ObjRsp = new cl_Usuario();
            DataTable dataTable = new DataTable();
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            try
            {
                dataTable = this.MetCliente.ConsultaUsuario();
                if (dataTable.Rows.Count <= 0)
                {
                    respuestaModelo.ProcesoExitoso = false;
                }
                else
                {
                    respuestaModelo.ProcesoExitoso = true;
                    ConversionClase ObjConversionClase = new ConversionClase();
                    ObjRsp = ObjConversionClase.UserConvert(dataTable);

                    if (!string.IsNullOrEmpty(ObjRsp.UserName))
                    {
                        rsp = BCrypt.Net.BCrypt.Verify(passwordIngresado, ObjRsp.PassWord);
                    }
                }
            }
            catch (Exception)
            {
                rsp = false;
            }
            return rsp;
            /*
            // 1. Buscar usuario en la base de datos
            var usuario = _context.tblUsuarios_Ramo
                                  .FirstOrDefault(u => u.UserName == userName && u.Activo == true);

            if (usuario == null) return false;

            // 2. Verificar si el password ingresado coincide con el Hash guardado
            bool esValido = BCrypt.Net.BCrypt.Verify(passwordIngresado, usuario.PassWord);

            return esValido;
            */
        }
    }
}
