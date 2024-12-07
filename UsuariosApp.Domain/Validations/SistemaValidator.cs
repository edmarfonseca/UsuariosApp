using FluentValidation;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validations
{
    public class SistemaValidator : AbstractValidator<Sistema>
    {
        public SistemaValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome do sistema é obrigatório.")
                .MaximumLength(50).WithMessage("O nome do sistema deve conter, no máximo, 50 caracteres.");

            RuleFor(u => u.Codigo)
                 .NotEmpty().WithMessage("O código do sistema é obrigatório.")
                 .MaximumLength(10).WithMessage("O código do sistema deve conter, no máximo, 10 caracteres.");

            RuleFor(u => u.Url)
                .NotEmpty().WithMessage("A URL do sistema é obrigatória.")
                .MaximumLength(250).WithMessage("A URL do sistema deve conter, no máximo, 250 caracteres.");
        }
    }
}