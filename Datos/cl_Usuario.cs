using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class cl_Usuario
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Salt { get; set; }
        public string FotoPerfil { get; set; }
        public bool Activo { get; set; }
        // Campos de auditoría
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
