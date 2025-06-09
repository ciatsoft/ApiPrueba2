using MVCDePrueba.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCDePrueba.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var responseToke = await new HttpClientConnection().GetToken("admin", "12345");
            var responseUsersList = await new HttpClientConnection().GetAllUsuarios(responseToke.access_token);
            return View();
        }
    }
}