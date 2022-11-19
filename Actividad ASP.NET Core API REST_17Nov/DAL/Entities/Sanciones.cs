using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad_ASP.NET_Core_API_REST_17Nov.DAL.Entities
{
    public class Sanciones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime FechaActual { get ; set; }

        [ForeignKey("IDConductor")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string ConductorID { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(100, ErrorMessage = "La longitud maxima del campo es de 100 caracteres")]
        public string Sancion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(int.MaxValue, ErrorMessage = "La longitud maxima del campo es flexible en cuanto a caracteres")]
        public string Observacion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public decimal Valor { get; set; }

        //Referencio la tabla asociada
        public virtual Conductor Conductor { get; set; }
    }
}
