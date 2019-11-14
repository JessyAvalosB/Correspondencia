using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Correspondencia.Controllers
{
    public class BusquedaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public String getDocumentosYear(String año)
        {
            Correspondencia.DB.DB db = new Correspondencia.DB.DB();
            List<Correspondencia.Models.Documents.DocumentDetails> docuemntoyear = new List<Correspondencia.Models.Documents.DocumentDetails>();

            docuemntoyear = db.getDocumentoYear(año, 1);

            // Console.WriteLine("Hello World!");
            String documentYear = Newtonsoft.Json.JsonConvert.SerializeObject(docuemntoyear).ToString();
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            // return serializer.Serialize(lista);

            return documentYear;
        }


        [HttpGet]
        public String getDependencias()
        {
            Correspondencia.DB.DB db = new Correspondencia.DB.DB();
            List<Correspondencia.Models.Documents.DocDependencia> Dependencias = new List<Correspondencia.Models.Documents.DocDependencia>();

            Dependencias = db.getDependencias();

            // Console.WriteLine("Hello World!");
            String DependeciaActal = Newtonsoft.Json.JsonConvert.SerializeObject(Dependencias).ToString();
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            // return serializer.Serialize(lista);

            return DependeciaActal;
        }



        [HttpGet]
        public String setFirmante(String json)
        {

            var jObject1 = JObject.Parse(json);




            Correspondencia.DB.DB db = new Correspondencia.DB.DB();
            Correspondencia.Models.Documents.DocRemitentes Firmante = new Correspondencia.Models.Documents.DocRemitentes();
            Firmante.ID_ORIGEN = (int)jObject1["ID_ORIGEN"];
            Firmante.NOMBRE = (string)jObject1["NOMBRE"];
            Firmante.APELLIDO_PATERNO = (string)jObject1["APELLIDO_PATERNO"];
            Firmante.APELLIDO_MATERNO = (string)jObject1["APELLIDO_MATERNO"];
            Firmante.CARGO = (string)jObject1["CARGO"];
            Firmante.CORREO = (string)jObject1["CORREO"];
            Firmante.TELEFONO = (string)jObject1["TELEFONO"];

            db.setFirmante(Firmante);

            return "";
        }
    }
}