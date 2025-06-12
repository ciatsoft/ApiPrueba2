using MVCDePrueba.Models;
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
        public async Task<ModelResponse> GetAllPublicaciones()
        {
            var result = await RequestAsync($"api/Publicaciones/GetAllPublicaciones", HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }), tokenCookie.token.access_token);

            var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(result);

            return modelResponse;
        }
    }
}