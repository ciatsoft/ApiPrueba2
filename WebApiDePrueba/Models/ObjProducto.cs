using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDePrueba.Models
{
    public class ObjProducto : BaseObject
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public bool Estatus { get; set; }
    }
}