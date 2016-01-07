using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dParadig.ViewModels
{
    public class HorariosVM
    {
        public int IdJefe { get; set; }
        public string NombreJefe { get; set; }
        public int Lunes { get; set; }
        public int Martes { get; set; }
        public int Miercoles { get; set; }
        public int Jueves { get; set; }
        public int Viernes { get; set; }
    }
}