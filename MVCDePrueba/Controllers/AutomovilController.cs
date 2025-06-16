using MVCDePrueba.Models;
using MVCDePrueba.Models.Autenticacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static MVCDePrueba.Helpers.FiltersHelpers;

namespace MVCDePrueba.Controllers
{
    // GET: Automovil
    [Autenticated]
    public class AutomovilController : BaseController
    {
        // GET: Automovil
        public async Task<ActionResult> Index()
        {
            var responseToke = await http.GetToken("admin", "12345");
            var responseAutomovil = await http.GetAllAutomovil();
            return View();
        }
        public async Task<ActionResult> Crud(int id = 0)
        {
            ObjAutomovil obj;

            if (id != 0)
            {
                var automovilResponse = await http.GetAutomovilForId(id);
                obj = JsonConvert.DeserializeObject<ObjAutomovil>(automovilResponse.Response.ToString());
            }
            else
            {
                obj = new ObjAutomovil();
            }

            return View(obj);
        }
        public async Task<ActionResult> SaveOrUpdateAutomovil(ObjAutomovil obj)
        {
            await http.SaveOrUpdateAutomovil(obj);
            return Redirect("Crud");
        }
    }
}