using FluentValidation;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validations
{
    public class PerfilApiValidator : AbstractValidator<PerfilApi>
    {
        public PerfilApiValidator()
        {
            RuleFor(u => u.PerfilId)
            .NotEmpty().WithMessage("O código do perfil de Perfil/API é obrigatório.");

            RuleFor(u => u.ApiId)
                .NotEmpty().WithMessage("O código da API de Perfil/API é obrigatório.");
        }
    }
}