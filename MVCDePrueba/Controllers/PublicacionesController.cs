using MVCDePrueba.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCDePrueba.Controllers
{
    public class PublicacionesController : BaseController
    {
        // GET: Publicaciones
        public async Task<ActionResult> Index()
        {
            var responseToke = await http.GetToken("admin", "12345");
            var responsePublicaciones = await http.GetAllPublicaciones(responseToke.access_token);
            return View();
        }
    }
}