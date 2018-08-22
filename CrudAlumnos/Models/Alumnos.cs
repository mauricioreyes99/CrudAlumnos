using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudAlumnos.Models
{
    public class Alumnos
    {
        [Key]
        public int Id_alumno { get; set; }

        [StringLength(30, ErrorMessage ="Debe ingresar un max de 30 caracteres y un minimo de 3", MinimumLength =3)]
        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="No puede dejar el campo {0} vacío")]
        public string NombreAlumno { get; set; }

        [StringLength(30, ErrorMessage = "Debe ingresar un max de 30 caracteres y un minimo de 5", MinimumLength = 5)]
        [Display(Name ="Apellido")]
        [Required(ErrorMessage = "No puede dejar el campo {0} vacío")]
        public string ApelidoAlumno { get; set; }

        [Display(Name ="Direccion")]
        [Required(ErrorMessage = "No puede dejar el campo {0} vacío")]
        public string DireccionAlumno { get; set;}

        [Display(Name ="Telefono")]
        [Required(ErrorMessage = "No puede dejar el campo {0} vacío")]
        public int TelefonoAlumno { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string EmailAlumno { get; set; }

        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}", ApplyFormatInEditMode =true)]
        [Display(Name ="Fecha de Ingreso")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "No puede dejar el campo {0} vacío")]
        public DateTime FechaIngreso { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh:mm}",ApplyFormatInEditMode =true)]
        [Display(Name ="Hora de ingreso")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "No puede dejar el campo {0} vacío")]
        public DateTime HoraIngreso { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo {0} vacío")]
        public int IDGrado { get; set; }

        public virtual CGradoAlumno CGradoAlumno { get; set; }
    }
}