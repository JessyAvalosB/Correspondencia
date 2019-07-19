using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondencia.Models.Documents
{
    public class AddDocModel
    {
        public int ID_REM { get; set; }
        public int ID_DIR { get; set; }
        public int ID_TIP { get; set; }
        public string FOLIO { get; set; }
        public int TURNADO { get; set; }
        public int ESTADO { get; set; }
        public string RESUMEN { get; set; }
        public string PDF { get; set; }
        public int COPIA { get; set; }


    }
}
