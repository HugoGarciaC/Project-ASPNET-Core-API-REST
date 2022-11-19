using Actividad_ASP.NET_Core_API_REST_17Nov.DTOs;
using FluentValidation;

namespace Actividad_ASP.NET_Core_API_REST_17Nov.Utils
{
    public class ConductorValidation : AbstractValidator<ConductorDTO>
    {
        public ConductorValidation()
        {
            RuleFor(s => s.Identificacion).NotEmpty().
                WithMessage("La identificación es un campo obligatorio");
            RuleFor(s => s.Identificacion).Length(0, 15).WithMessage("La " +
                "identificación no puede superar los 15 caracteres");

            RuleFor(s => s.Nombre).NotEmpty().
                WithMessage("El nombre es un campo obligatorio");
            RuleFor(s => s.Nombre).Length(0, 20).WithMessage("El " +
                "nombre no puede superar los 20 caracteres");

            RuleFor(s => s.Apellidos).NotEmpty().
                WithMessage("Los apellidos son un campo obligatorio");
            RuleFor(s => s.Apellidos).Length(0, 20).WithMessage("Los " +
                "apellidos no pueden superar los 20 caracteres");

            RuleFor(s => s.Direccion).NotEmpty().
                WithMessage("La dirección es un campo obligatorio");
            RuleFor(s => s.Direccion).Length(0, 30).WithMessage("La " +
                "dirección no puede superar los 30 caracteres");

            RuleFor(s => s.Telefono).NotEmpty().
                WithMessage("El telefono es un campo obligatorio");
            RuleFor(s => s.Telefono).Length(0, 15).WithMessage("El " +
                "telfono no puede superar los 15 caracteres");

            RuleFor(s => s.Email).NotEmpty()
                .WithMessage("El correo es un campo obligatorio.")
           .EmailAddress()
                .WithMessage("Por favor ingrese una dirección de correo electrónico válida.")
           .Length(0, 30).WithMessage("El" +
                "correo no puede superar los 30 caracteres"); ;

            RuleFor(s => s.MatriculaID).NotEmpty().
                WithMessage("El numero de la matricula es un campo obligatorio");
            RuleFor(s => s.MatriculaID).Length(0, 15).WithMessage("El " +
                "nombre no puede superar los 15 caracteres");
        }
    }
}
