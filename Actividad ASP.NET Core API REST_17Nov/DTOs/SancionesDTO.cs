using System;

namespace Actividad_ASP.NET_Core_API_REST_17Nov.DTOs
{
    public class SancionesDTO
    {
        public int ID { get; set; }

        public DateTime FechaActual { get; set; }

        public string ConductorID { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Sancion { get; set; }

        public string Observacion { get; set; }

        public decimal Valor { get; set; }
    }
}
