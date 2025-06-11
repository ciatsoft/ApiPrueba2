using MVCDePrueba.DAL;
using MVCDePrueba.Models.Autenticacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVCDePrueba.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Autenticacion()
        {
            //var responseToke = await http.GetToken("admin", "12345");
            //responseToke.ExpirationDate = DateTime.Now.AddSeconds(responseToke.expires_in);
            //
            //var responseUsersList = await http.GetAllUsuarios(responseToke.access_token);
            //
            //Helpers.SessionHelper.CreateDession(new Models.Autenticacion.TokenCookie()
            //{ 
            //    token = responseToke,
            //    userName = "admin"
            //});

            return View();
        }
        public async Task<ActionResult> Index()
        {
            var usuarioAutenticado = Helpers.SessionHelper.GetSession();

            ViewBag.UsuarioAutenticado = usuarioAutenticado.userName;
            return View();
        }
        [HttpPost]
        public async Task<string> AutenticacionDeUsuario(ObjUsuario u)
        {
            try
            {
                var responseToken = await http.GetToken(u.UserName, u.Pass);
                responseToken.ExpirationDate = DateTime.Now.AddSeconds(responseToken.expires_in);
                Helpers.SessionHelper.CreateDession(new Models.Autenticacion.TokenCookie()
                { 
                    token = responseToken,
                    userName = u.UserName
                });

                mr.Result.Success = true;
            }
            catch (Exception ex)
            {
                mr.Result.ErrorMessage = ex.Message;
                mr.Result.Success = false;
            }

            return JsonConvert.SerializeObject(mr);

        }
    }
}