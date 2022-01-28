using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//Quitamos del siguiente namespace, el término .MataClasses para asociar la misma ruta a nuestra clase Alumno
namespace AdministracionEscuela.Models
{
    public class AlumnosMetadata
    {
        [StringLength(30)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [StringLength(30)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Fecha de inscripción")]
        public Nullable<System.DateTime> FechaInscripcion { get; set; }
    }

    //Asociamos las validaciones del Metadata a la clase Alumno
    [MetadataType(typeof(AlumnosMetadata))]
    public partial class Alumno
    {

    }


}