using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondencia.Models.Documents
{
    public class DocRemitentes
    {

        public int CAT_REMITENTES { get; set; }
        public int ID_REMITENTE { get; set; }
        public int ID_ORIGEN { get; set; }
        [Required]
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        [Required]
        public string APELLIDO_MATERNO { get; set; }
        [Required]
        public string CARGO { get; set; }
        [Required]
        public string CORREO { get; set; }
        [Required]
        public string TELEFONO { get; set; }
        public string NOMBREORIGEN { get; set; }

    }
}
