using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RespuestaModelo
    {
        public string DetalleError
        {
            get;
            set;
        }

        public string MensajeError
        {
            get;
            set;
        }

        public string NumeroError
        {
            get;
            set;
        }

        public bool ProcesoExitoso
        {
            get;
            set;
        }

        public List<object> Respuesta
        {
            get;
            set;
        }

        public RespuestaModelo()
        {
            this.Respuesta = new List<object>();
        }
    }
}
