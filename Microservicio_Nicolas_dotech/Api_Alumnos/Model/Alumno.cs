﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Alumnos.Model
{
    /// <summary>
    /// props
    /// </summary>
    public class Alumno
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int MateriaId { get; set; }

    }
}
