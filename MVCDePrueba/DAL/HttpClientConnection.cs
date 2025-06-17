using MVCDePrueba.Helpers;
using MVCDePrueba.Models;
using MVCDePrueba.Models.Autenticacion;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCDePrueba.DAL
{
    public partial class HttpClientConnection : HttpClientBase
	{
        public TokenCookie tokenCookie { get; set; }
        public HttpClientConnection()
        {
            tokenCookie = SessionHelper.GetSession();
        }
        public async Task<Token> GetToken(string user, string pass)
        {
            return await TokenAsync<Token>("token",
                new[]
                    {
                        new KeyValuePair<string, string>("grant_type","password"),
                        new KeyValuePair<string, string>("UserName",user),
                        new KeyValuePair<string, string>("Password",pass)
                    }, "application/x-www-url-formencoded");
        }
        public BaseObject MappingColumSecurity(BaseObject o)
        {
            if (o.Id == 0 || o.Id == -1)
            {
                o.CreatedBy = SessionHelper.GetSession().userName;
                o.CreatedDt = DateTime.Now;
            }
            else
            {
                o.UpdatedBy = SessionHelper.GetSession().userName;
                o.UpdatedDt = DateTime.Now;
            }

            return o;
        }
    }
}