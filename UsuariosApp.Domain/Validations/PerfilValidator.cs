using FluentValidation;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validations
{
    public class PerfilValidator : AbstractValidator<Perfil>
    {
        public PerfilValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome do perfil é obrigatório.")
                .MaximumLength(25).WithMessage("O nome do perfil deve conter, no máximo, 25 caracteres.");
                       
            RuleFor(u => u.SistemaId)
                .NotEmpty().WithMessage("O código do sistema do perfil é obrigatório.");
        }
    }
}