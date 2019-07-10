using System;
using System.Collections.Generic;
using Correspondencia.Models;
using Correspondencia.Models.Documents;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace Correspondencia.Controllers
{
    public class DocumentsController : Controller
    {
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
        public ActionResult AddDoc(AddDocModel addDoc)
        {
            
            return RedirectToAction("Index", "Home");
        }
    }
}