using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad_ASP.NET_Core_API_REST_17Nov.DAL.Entities
{
    public class Conductor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(15, ErrorMessage = "La longitud maxima del campo es de 15 caracteres")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "La longitud maxima del campo es de 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "La longitud maxima del campo es de 20 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(30, ErrorMessage = "La longitud maxima del campo es de 30 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(15, ErrorMessage = "La longitud maxima del campo es de 15 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(30, ErrorMessage = "La longitud maxima del campo es de 30 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime FechaNacimiento { get; set; }

        public bool? Activo { get; set; }

        [ForeignKey("IDMatricula")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string MatriculaID { get; set; }

        //Referencio la tabla asociada
        public virtual Matricula Matricula { get; set; }
    }
}
