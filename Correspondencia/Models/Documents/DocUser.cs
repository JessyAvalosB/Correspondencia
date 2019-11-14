using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondencia.Models.Documents
{
    public class DocUser
    {

        public int ID_USUARIO { get; set; }
        [Required]
        public int ID_DIRECCION { get; set; }
        public int TIPO_USUARIO { get; set; }
        [Required]
        public string NOMBRE { get; set; }
        [Required]
        public string APELLIDO_PATERNO { get; set; }
        [Required]
        public string APELLIDO_MATERNO { get; set; }
        [Required]
        public string CORREO { get; set; }
        [Required]
        public string TELEFONO { get; set; }

    }
}
