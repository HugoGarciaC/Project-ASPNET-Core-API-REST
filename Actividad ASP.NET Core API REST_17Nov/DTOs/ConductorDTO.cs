using System;
using System.ComponentModel.DataAnnotations;

namespace Actividad_ASP.NET_Core_API_REST_17Nov.DTOs
{
    public class ConductorDTO
    {
        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime FechaNacimiento { get; set; }

        public bool? Activo { get; set; }

        public string MatriculaID { get; set; }

        public DateTime FechaExpedicion { get; set; }

        public DateTime ValidaHasta { get; set; }
    }
}
