using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondencia.Models
{
    public class SignatoryModel
    {
        public int ID_REMITENTE { get; set; }
        public int ID_ORIGEN { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string CARGO { get; set; }
        public string CORREO { get; set; }
        public string TELEFONO { get; set; }

    }
}
