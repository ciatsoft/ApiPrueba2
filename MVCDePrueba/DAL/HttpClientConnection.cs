
﻿using MVCDePrueba.Models.Autenticacion;
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
    }
}