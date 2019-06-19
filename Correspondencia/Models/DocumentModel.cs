using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondencia.Models
{
    public class DocumentModel
    {
        public int ENVIADO { get; set; }
        public DateTime FECHACAPTURA { get; set; }
        public int EXISTEFISICAMENTE { get; set; }
        public int RECIBIDO { get; set; }
        public string NOMBREDESTINO { get; set; }
        public string DIRECCIONDESTINO { get; set; }
        public string NOMBREREMITENTE { get; set; }
        public string CARGO { get; set; }
        public string DIRECCIONORIGEN { get; set; }
        public string TIPODOCUMENTO { get; set; }


    }
}
