using MVCDePrueba.DAL;
using MVCDePrueba.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using static MVCDePrueba.Helpers.FiltersHelpers;

namespace MVCDePrueba.Controllers
{
    [Autenticated]
    public class PublicacionesController : BaseController
    {
        // GET: Publicaciones
        public async Task<ActionResult> Index()
        {
            var responseToke = await http.GetToken("admin", "12345");
            var responsePublicaciones = await http.GetAllPublicaciones();
            return View();
        }
        public async Task<ActionResult> Crud(int id = 0)
        {
            ObjPublicaciones obj;            

            if (id != 0)
            {
                var publicacionesResponse = await http.GetPublicacionesForId(id);
                obj = JsonConvert.DeserializeObject<ObjPublicaciones>(publicacionesResponse.Response.ToString());
            }
            else
            {
                obj = new ObjPublicaciones();
            }

            return View(obj);
        }
        public async Task<ActionResult> SaveOrUpdatePublicaciones(ObjPublicaciones obj)
        {
            await http.SaveOrUpdatePublicaciones(obj);
            return Redirect("../Home/Index");
        }
    }
}