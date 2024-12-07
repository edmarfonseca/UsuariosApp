using FluentValidation;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validations
{
    public class ClienteSistemaValidator : AbstractValidator<ClienteSistema>
    {
        public ClienteSistemaValidator()
        {
            RuleFor(u => u.ClienteId)
            .NotEmpty().WithMessage("O código do cliente de Cliente/Sistema é obrigatório.");

            RuleFor(u => u.SistemaId)
                .NotEmpty().WithMessage("O código do sistema de Cliente/Sistema é obrigatório.");
        }
    }
}