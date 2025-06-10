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
            var response = new ModelResponse()
            {
                Response = wrapper.GetAllUsuario(out OperationResult result),
                Result = result
            };
            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Autenticacion")]
        public ModelResponse Autenticacion(ObjUsuario request)
        {
            var response = new ModelResponse()
            {
                Response = wrapper.GetUserByUserNameAndPass(request.UserName, request.Pass, out OperationResult result),
                Result = result
            };
            return response;
        }


        [HttpGet]
        [Route("GetAllLaptop")]
        public ModelResponse GetAllLaptop()
        {
            var response = new ModelResponse()
            {
                Response = wrapper.GetAllLaptop(out OperationResult result),
                Result = result
            };
            return response;
        }

        [HttpPost]
        [Route("AutenticacionLaptop")]
        public ModelResponse AutenticacionLaptop(ObjLaptop request)
        {
            var response = new ModelResponse()
            {
                Response = wrapper.GetLaptopByBrand(request.Brand, out OperationResult result),
                Result = result
            };
            return response;
        }
    }
}
