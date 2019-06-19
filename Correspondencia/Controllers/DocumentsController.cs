using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Correspondencia.Controllers
{
    public class DocumentsController : Controller
    {
        public IActionResult Search()
        {
            return View();
        }

        public IActionResult AddDoc()
        {
            return View();
        }
    }
}