using System;
using System.ComponentModel.DataAnnotations;

namespace Actividad_ASP.NET_Core_API_REST_17Nov.DTOs
{
    public class MatriculaDTO
    {
        public int ID { get; set; }

        public string Numero { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime FechaExpedicion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime ValidaHasta { get; set; }

        public bool? Activo { get; set; }
    }
}
