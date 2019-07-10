using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondencia.Models.Documents
{
    public class AddDocModel
    {

        public int COPIA { get; set; }
        [Required]
        public string FOLIO { get; set; }
        public string FILE_URL { get; set; }
        [Required]
        public string RESUMEN { get; set; }
        [Required]
        public int DESTINATARIO { get; set; }
        [Required]
        public int REMITENTE { get; set; }
        [Required]
        public int ID_TIPO_DOCUMENTO { get; set; }
       
    }
}
