using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("{Nombre} no puede estar en blanco.")
            .NotNull().WithMessage("{Nombre} no puede ser nulo.")
            .MaximumLength(80).WithMessage("{Nombre} no puede exceder de 80 caracteres.");


            RuleFor(p => p.Apellido)
            .NotEmpty().WithMessage("{Apellido} no puede estar en blanco.")
            .NotNull().WithMessage("{Apellido} no puede ser nulo.")
            .MaximumLength(80).WithMessage("{Apellido} no puede exceder de 80 caracteres.");
        }
    }
}
