using Actividad_ASP.NET_Core_API_REST_17Nov.DTOs;
using FluentValidation;

namespace Actividad_ASP.NET_Core_API_REST_17Nov.Utils
{
    public class MatriculaValidation : AbstractValidator<MatriculaDTO>
    {
        public MatriculaValidation()
        {
            RuleFor(s => s.Numero).NotEmpty().
                WithMessage("Numero de matricula es un campo obligatorio");
            RuleFor(s => s.Numero).Length(0, 15).WithMessage("El " +
                "numero de matricula no puede superar los 15 caracteres");
            RuleFor(s => s.Activo).Null();
        }
    }
}
