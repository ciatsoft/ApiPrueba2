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
using static MVCDePrueba.Helpers.FiltersHelpers;

namespace MVCDePrueba.Controllers
{
    public class HomeController : BaseController
    {
        #region Vistas
        [NoAutenticated]
        public ActionResult Autenticacion()
        {
            return View();
        }
        [Autenticated]
        public ActionResult Index()
        {
            return View();
        }
        #endregion


        #region Acceso a Datos
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

        public async Task<string> GetAllPublicacionces()
        {
            var response = await http.GetAllPublicaciones();
            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> GetAllAutomovil()
        {
            var response = await http.GetAllAutomovil();
            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> GetAllLaptop(ObjUsuario u)
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
        #endregion
    }
}