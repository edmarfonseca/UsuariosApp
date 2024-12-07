using FluentValidation;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                .MaximumLength(150).WithMessage("O nome do usuário deve conter, no máximo, 150 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O email do usuário é obrigatório.")
                .EmailAddress().WithMessage("O email informado é inválido.");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("A senha do usuário é obrigatória.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                    .WithMessage("A senha deve conter, pelo menos, 8 caracteres, incluindo letras maiúsculas, minúsculas, números e símbolos.");
        }
    }
}