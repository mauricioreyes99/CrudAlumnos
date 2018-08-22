using CrudAlumnos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudAlumnos.AlumnosContext
{
    public class AlumnosC : DbContext
    {
        public DbSet <Alumnos> Alumnos { get; set; }

        public System.Data.Entity.DbSet<CrudAlumnos.Models.CGradoAlumno> CGradoAlumnoes { get; set; }
    }
}