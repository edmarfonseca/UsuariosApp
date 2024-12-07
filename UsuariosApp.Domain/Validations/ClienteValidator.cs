using FluentValidation;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(u => u.Nome)
            .NotEmpty().WithMessage("O nome/razão social do cliente é obrigatório.")
            .MaximumLength(100).WithMessage("O nome/razão social do cliente deve conter, no máximo, 100 caracteres.");

            RuleFor(u => u.CpfCnpj)
            .NotEmpty().WithMessage("O CPF/CNPJ do cliente é obrigatório.");

            RuleFor(u => u.Logradouro)
            .NotEmpty().WithMessage("O logradouro do cliente é obrigatório.")
            .MaximumLength(50).WithMessage("O logradouro do cliente deve conter, no máximo, 50 caracteres.");

            RuleFor(u => u.Numero)
            .NotEmpty().WithMessage("O número do endereço do cliente é obrigatório.");

            RuleFor(u => u.Bairro)
            .NotEmpty().WithMessage("O bairro do cliente é obrigatório.")
            .MaximumLength(50).WithMessage("O bairro do cliente deve conter, no máximo, 50 caracteres.");

            RuleFor(u => u.Cidade)
            .NotEmpty().WithMessage("A cidade do cliente é obrigatória.")
            .MaximumLength(50).WithMessage("A cidade do cliente deve conter, no máximo, 50 caracteres.");

            RuleFor(u => u.Uf)
            .NotEmpty().WithMessage("O estado do cliente é obrigatório.")
            .Length(2).WithMessage("O estado do cliente deve conter 2 caracteres.");

            RuleFor(u => u.Cep)
            .NotEmpty().WithMessage("O cep do cliente é obrigatório.")
            .Matches(@"^\d{8}$").WithMessage("O cep do cliente deve conter 8 números.");
        }
    }
}