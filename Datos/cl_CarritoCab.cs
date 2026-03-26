using System;
using System.Collections.Generic;

namespace Datos
{
    public class cl_CarritoCab
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public bool Estado { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public string SessionId { get; set; }

        public List<cl_CarritoDet> LstCarritoDet { get; set; }

        public string UsuarioCreacion { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime? Fecha_Modificacion { get; set; }
    }
}
