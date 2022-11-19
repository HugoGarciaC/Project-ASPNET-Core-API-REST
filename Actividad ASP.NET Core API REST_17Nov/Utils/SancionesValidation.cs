using Actividad_ASP.NET_Core_API_REST_17Nov.DTOs;
using FluentValidation;

namespace Actividad_ASP.NET_Core_API_REST_17Nov.Utils
{
    public class SancionesValidation : AbstractValidator<SancionesDTO>
    {
        public SancionesValidation()
        {
            RuleFor(s => s.ConductorID).NotEmpty().
                WithMessage("La identificación del conductor es un campo obligatorio");
            RuleFor(s => s.ConductorID).Length(0, 15).WithMessage("La" +
                "identificación del conductor no puede superar los 15 caracteres");

            RuleFor(s => s.Sancion).NotEmpty().
                WithMessage("La sanción es un campo obligatorio");
            RuleFor(s => s.Sancion).Length(0, 100).WithMessage("La " +
                "sanción no puede superar los 100 caracteres");

            RuleFor(s => s.Observacion).NotEmpty().
                WithMessage("La observación es un campo obligatorio");

            RuleFor(s => s.Valor).GreaterThan(0).
                WithMessage("El valor debe ser mayor a cero");
        }
    }
}
