using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDePrueba.Models
{
    public class ObjPublicaciones : BaseObject
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
    }
}