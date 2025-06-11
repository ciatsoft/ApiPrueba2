using MVCDePrueba.Models;
using MVCDePrueba.Models.Autenticacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MVCDePrueba.DAL
{

	public partial class HttpClientConnection
	{

        public async Task<ModelResponse> GetAllUsuarios(string token)
        {
            var result = await RequestAsync($"api/Usuario/GetAllUsuario", HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }), token);

            var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(result);

            return modelResponse;
        }
    }
}