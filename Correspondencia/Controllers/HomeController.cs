using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Correspondencia.DB;
using Correspondencia.Models;
using System.Data;
using Correspondencia.Models.Documents;
using Microsoft.AspNetCore.Http;

namespace Correspondencia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {

            Correspondencia.DB.DB db = new Correspondencia.DB.DB();

            List<DocumentModel> documents = new List<DocumentModel>();

            documents = db.getDocuments();

            ViewBag.Documents = documents;

            return View();
        }

        [HttpGet]
        public String Details(String id)
        {
            Correspondencia.DB.DB db = new Correspondencia.DB.DB();
            List<DocumentDetails> details = new List<DocumentDetails>();

            details = db.getDocDetails(id);

            // Console.WriteLine("Hello World!");
            String usuarioActal = Newtonsoft.Json.JsonConvert.SerializeObject(details).ToString();
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            // return serializer.Serialize(lista);
            ViewBag.Details = details;
            return usuarioActal;
        }

        [HttpPost]
        public IActionResult Home(IFormCollection formCollection)
        {
            return RedirectToAction("Home", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
