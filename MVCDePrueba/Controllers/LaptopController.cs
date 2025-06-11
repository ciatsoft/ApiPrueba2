using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCDePrueba.Controllers
{
    public class LaptopController : BaseController
    {
        // GET: Laptop
        public async Task<ActionResult> Index()
        {
            var responseToke = await http.GetToken("admin", "12345");
            var responseLaptopsList = await http.GetAllLaptop(responseToke.access_token);
            return View();
        }
    }
}