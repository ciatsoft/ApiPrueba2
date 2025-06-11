using MVCDePrueba.Models.Autenticacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDePrueba.Helpers
{
    public class SesisonHelpers
    {
        public static void CreateSession(string id)
        {

        }
        public static TokenCookie GetSession()
        {
            return new TokenCookie();
        }
    }
}