using System;
using System.Collections.Generic;
using Correspondencia.Models;
using Correspondencia.Models.Documents;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http.Headers;

namespace Correspondencia.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IHostingEnvironment _host;

        public DocumentsController(IHostingEnvironment host)
        {
            _host = host;
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddDoc()
        {
            Correspondencia.DB.DB db = new Correspondencia.DB.DB();

            List<DocTypeModel> docTypes = new List<DocTypeModel>();
            List<DocDestinationModel> docDestinations = new List<DocDestinationModel>();
            List<DocSignatoryModel> docSignatories = new List<DocSignatoryModel>();

            docSignatories = db.getDocSignatories();

            docDestinations = db.getDocDestination();

            docTypes = db.getDocType();

            ViewBag.DocTypes = docTypes;
            ViewBag.DocDestination = docDestinations;
            ViewBag.DocSignatories = docSignatories;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddDoc(IFormCollection formCollection, IFormFile files)
        {
            Correspondencia.DB.DB db = new Correspondencia.DB.DB();
            AddDocModel addDoc = new AddDocModel();

            string folio = formCollection["FOLIO"];
            int type = Int32.Parse(formCollection["TYPE"]);
            int destinatario = Int32.Parse(formCollection["DESTINATARIO"]);
            int remitente = Int32.Parse(formCollection["REMITENTE"]);
            string resumen = formCollection["RESUMEN"];
            int turnado = 1;
            int estado = 0;
            int copia = 1;
            string goodPath = Path.Combine("/", files.FileName);
            // full path to file in temp location
            string path = Path.Combine("wwwroot/",
                       files.FileName);

            if (files.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await files.CopyToAsync(stream);
                }
            }

            addDoc.ID_REM = remitente;
            addDoc.ID_DIR = destinatario;
            addDoc.ID_TIP = type;
            addDoc.FOLIO = folio;
            addDoc.TURNADO = turnado;
            addDoc.ESTADO = estado;
            addDoc.RESUMEN = resumen;
            addDoc.PDF = goodPath;
            addDoc.COPIA = copia;

            db.insertDocument(addDoc);
            
            return RedirectToAction("Home", "Home");
        }

      
    }
}