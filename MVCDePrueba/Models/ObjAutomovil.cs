using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDePrueba.Models

{
    public class ObjAutomovil : BaseObject
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public decimal Precio { get; set; }
        public string Condicion { get; set; }
        public string TCombustible { get; set; }
    }
}