using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Correspondencia.Controllers
{
    public class SignatoryController : Controller
    {
        public IActionResult AddRemitente()
        {
            return View();
        }

        public IActionResult EditRemitente()
        {
            return View();
        }
    }
}