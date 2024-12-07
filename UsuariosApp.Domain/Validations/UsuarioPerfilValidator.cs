using FluentValidation;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validations
{
    public class UsuarioPerfilValidator : AbstractValidator<UsuarioPerfil>
    {
        public UsuarioPerfilValidator()
        {
            RuleFor(u => u.UsuarioId)
            .NotEmpty().WithMessage("O código do usuário de Usuário/Perfil é obrigatório.");

            RuleFor(u => u.ClienteSistemaId)
            .NotEmpty().WithMessage("O código do sistema de Usuário/Perfil é obrigatório.");

            RuleFor(u => u.PerfilId)
            .NotEmpty().WithMessage("O código do perfil de Usuário/Perfil é obrigatório.");
        }
    }
}