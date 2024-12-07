using FluentValidation;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validations
{
    public class ApiValidator : AbstractValidator<Api>
    {
        public ApiValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome da API é obrigatório.")
                .MaximumLength(50).WithMessage("O nome da API deve conter, no máximo, 50 caracteres.");

            RuleFor(u => u.Uri)
                .NotEmpty().WithMessage("A URI da API é obrigatória.")
                .MaximumLength(250).WithMessage("A URI da API deve conter, no máximo, 250 caracteres.");

            RuleFor(u => u.SistemaId)
                .NotEmpty().WithMessage("O código do sistema da API é obrigatório.");
        }
    }
}