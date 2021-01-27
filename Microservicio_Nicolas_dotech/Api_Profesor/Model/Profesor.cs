﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Profesor.Model
{
    public class Profesor
    {
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime FechaIncorporacion { get; set; }
        public string MateriaId { get; set; }
       
    }
}
