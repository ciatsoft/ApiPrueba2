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
<<<<<<< HEAD
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
=======
>>>>>>> parent of 78dfde0 (Merge pull request #7 from ciatsoft/feature/RamaTrabajoIvan)
    }
}