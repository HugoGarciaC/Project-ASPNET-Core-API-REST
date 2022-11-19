using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad_ASP.NET_Core_API_REST_17Nov.DAL.Entities
{
    public class Matricula
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "La longitud maxima del campo es de 20 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime FechaExpedicion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime ValidaHasta { get; set; }

        public bool? Activo { get; set; }

        public virtual ICollection<Conductor> Conductor { get; set; }
    }
}
