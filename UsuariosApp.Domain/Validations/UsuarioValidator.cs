using FluentValidation;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validations
{
    /// <summary>
    /// Classe para validação dos dados do usuário
    /// </summary>
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("O id do usuário é obrigatório");

            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                .Length(6, 100).WithMessage("Informe o nome de 6 a 100 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O email do usuário é obrigatório.")
                .EmailAddress().WithMessage("O email informado é inválido.");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("A senha do usuário é obrigatória.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                    .WithMessage("A senha deve ter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas, números e símbolos.");
        }
    }
}
