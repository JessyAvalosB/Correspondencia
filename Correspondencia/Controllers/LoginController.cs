using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Correspondencia.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public String LoginUsuario(String usuario, String contraseña)
        {
            Correspondencia.DB.DB db = new Correspondencia.DB.DB();
            List<Correspondencia.Models.Documents.DocUser> usuarioActual = new List<Correspondencia.Models.Documents.DocUser>();

            usuarioActual = db.obtenerusuario(usuario, contraseña);

            // Console.WriteLine("Hello World!");
            String usuarioActal = Newtonsoft.Json.JsonConvert.SerializeObject(usuarioActual).ToString();
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            // return serializer.Serialize(lista);

            return usuarioActal;
        }
    }
}