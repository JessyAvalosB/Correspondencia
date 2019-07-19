using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondencia.Models
{
    public class DocumentModel
    {
        public string TURNADO { get; set; }

        public DateTime FECHA_CAPTURA { get; set; }

        public string COPIA_FISICA { get; set; }

        public string ESTADO { get; set; }

        public string DESTINO { get; set; }

        public string FIRMANTE { get; set; }

        public string CARGO { get; set; }

        public string ORIGEN { get; set; }

        public string TIPO { get; set; }

    }
}
