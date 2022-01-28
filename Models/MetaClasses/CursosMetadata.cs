using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

//Quitamos del siguiente namespace, el término .MataClasses para asociar la misma ruta a nuestra clase Curso
namespace AdministracionEscuela.Models
{
    public class CursosMetadata
    {
        [StringLength(30)]
        public string Nombre { get; set; }
        [Range(1,8)]
        public int Creditos { get; set; }
    }

    //Asociamos las validaciones del Metadata a la clase Curso
    [MetadataType(typeof(CursosMetadata))]
    public partial class Curso
    {

    }
}