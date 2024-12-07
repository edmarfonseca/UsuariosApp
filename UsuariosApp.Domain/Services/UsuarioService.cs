using FluentValidation;
using UsuariosApp.Domain.Dtos;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Validations;

namespace UsuariosApp.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioPerfilRepository _usuarioPerfilRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public UsuarioService(IUsuarioRepository usuarioRepository, IClienteRepository clienteRepository, IUsuarioPerfilRepository usuarioPerfilRepository, IJwtTokenService jwtTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _clienteRepository = clienteRepository;
            _usuarioPerfilRepository = usuarioPerfilRepository;
            _jwtTokenService = jwtTokenService;
        }

        public CriarUsuarioResponse CriarUsuario(CriarUsuarioRequest dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                ClienteId = dto.ClienteId
            };

            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (_usuarioRepository.Verify(usuario.Email))
                throw new ApplicationException("O e-mail informado já existe.");

            var cliente = _clienteRepository.Get(usuario.ClienteId);

            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado.");

            usuario.Cliente = cliente;
            usuario.Senha = SHA256Helper.Encrypt(usuario.Senha);

            _usuarioRepository.Add(usuario);

            return new CriarUsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataInclusao = usuario.DataInclusao,
                Cliente = new ClienteResponse
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    CpfCnpj = cliente.CpfCnpj
                }
            };
        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest dto)
        {
            var usuario = _usuarioRepository.Find(dto.Email, SHA256Helper.Encrypt(dto.Senha));

            if (usuario == null)
                throw new ApplicationException("E-mail/Senha incorretos.");

            var perfis = _usuarioPerfilRepository.Get(usuario);

            var response = new List<UsuarioPerfisResponse>();

            foreach (UsuarioPerfil perfil in perfis)
            {
                response.Add(
                    new UsuarioPerfisResponse
                    {
                        Id = perfil.ClienteSistema.Sistema.Id,
                        Nome = perfil.ClienteSistema.Sistema.Nome,
                        Codigo = perfil.ClienteSistema.Sistema.Codigo,
                        Perfil = new PerfilResponse
                        {
                            Id = perfil.Perfil.Id,
                            Nome = perfil.Perfil.Nome
                        }
                    }
                    );
            }

            return new AutenticarUsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAcesso = DateTime.Now,
                DataHoraExpiracao = _jwtTokenService.GenerateExpirationDate(),
                AccessToken = _jwtTokenService.GenerateToken(usuario),
                Sistemas = response
            };
        }
    }
}