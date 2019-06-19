using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Correspondencia.DB;
using Correspondencia.Models;
using System.Data;

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

        public IActionResult Home()
        {
            Correspondencia.DB.DB db = new Correspondencia.DB.DB();
            List<DocumentModel> documents = new List<DocumentModel>();
            documents = db.getDocuments();
            ViewBag.Documents = documents;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
