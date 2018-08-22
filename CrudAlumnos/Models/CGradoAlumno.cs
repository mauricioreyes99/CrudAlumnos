using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudAlumnos.Models
{
    public class CGradoAlumno
    {
        [Key]
        public int IDGrado { get; set; }

        public string GradoAlumno { get; set; }

        public virtual ICollection<Alumnos> Alumnos { get; set; }

    }
}