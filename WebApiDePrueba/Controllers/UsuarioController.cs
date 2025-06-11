using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using WebApiDePrueba.DAL;
using WebApiDePrueba.Models;

namespace WebApiDePrueba.Controllers
{
    
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        private DbWrapper wrapper;
        public UsuarioController()
        {
            wrapper = new DbWrapper();
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllUsuario")]
        public ModelResponse GetAllUsuario()
        {
            var respose = new ModelResponse()
            { 
                Response = wrapper.GetAllUsuario(out OperationResult result),
                Result = result
            };

            return respose;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Autenticacion")]
        public ObjUsuario Autenticacion(ObjUsuario request)
        {
            var response = wrapper.GetUserByUserNameAndPass(request.UserName, request.Pass);
            return response;
        }
    }
}
