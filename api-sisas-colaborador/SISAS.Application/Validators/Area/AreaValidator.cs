using FluentValidation;
using SISAS.Application.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Application.Validators.Area
{
    public class AreaValidator : AbstractValidator<AreaRequestDto>
    {
        public AreaValidator()
        {
            RuleFor(x => x.Nombre)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre no puede estar vacío.");

            RuleFor(x => x.Descripcion)
                .NotNull().WithMessage("El campo Descripcion no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Descripcion no puede estar vacío.");

        }
    }
}
