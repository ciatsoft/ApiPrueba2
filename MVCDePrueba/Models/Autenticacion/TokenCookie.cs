using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDePrueba.Models.Autenticacion
{
    public class TokenCookie
    {
        public Token token {  get; set; }
        public string userName { get; set; }    
    }
}