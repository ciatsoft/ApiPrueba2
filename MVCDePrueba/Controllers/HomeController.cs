using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCDePrueba.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Autenticacion()
        {
            return View();
        }
        public async Task<ActionResult> Index()
        {
            var responseToke = await http.GetToken("admin", "12345");
            var responseUsersList = await http.GetAllUsuarios(responseToke.access_token);
            return View();
        }
    }
}