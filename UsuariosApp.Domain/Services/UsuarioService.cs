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
        private readonly IPerfilRepository _perfilRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public UsuarioService(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository, IJwtTokenService jwtTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
            _jwtTokenService = jwtTokenService;
        }

        public CriarUsuarioResponseDto CriarUsuario(CriarUsuarioRequestDto dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };

            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);
           
            if (_usuarioRepository.Verify(usuario.Email))
                throw new ApplicationException("O email informado já está cadastrado, tente outro.");
                        
            usuario.Senha = SHA256Helper.Encrypt(usuario.Senha);
            
            var perfil = _perfilRepository.ObterPorNome("OPERADOR");
            usuario.PerfilId = perfil.Id;

            _usuarioRepository.Add(usuario);

            return new CriarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCadastro = DateTime.Now,
                Perfil = new PerfilResponseDto
                {
                    Id = perfil.Id,
                    Nome = perfil.Nome
                }
            };
        }

        public AutenticarUsuarioResponseDto AutenticarUsuario(AutenticarUsuarioRequestDto dto)
        {
            var usuario = _usuarioRepository.Find(dto.Email, SHA256Helper.Encrypt(dto.Senha));

            if (usuario == null)
                throw new ApplicationException("Acesso negado. Usuário inválido.");

            return new AutenticarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAcesso = DateTime.Now,
                DataHoraExpiracao = _jwtTokenService.GenerateExpirationDate(),
                AccessToken = _jwtTokenService.GenerateToken(usuario),
                Perfil = new PerfilResponseDto
                {
                    Id = usuario.Perfil.Id,
                    Nome = usuario.Perfil.Nome
                }
            };
        }
    }
}