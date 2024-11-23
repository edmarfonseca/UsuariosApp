using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            #region Capturando e validando os dados do usuário

            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };

            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            #endregion

            #region Regra: Não permitir o cadastro de usuários com o mesmo email

            if (_usuarioRepository.Verify(usuario.Email))
                throw new ApplicationException("O email informado já está cadastrado, tente outro.");

            #endregion

            #region Regra: A senha do usuário deve ser criptografada

            usuario.Senha = SHA256Helper.Encrypt(usuario.Senha);

            #endregion

            #region Regra: O usuário deverá ser associado ao perfil OPERADOR

            var perfil = _perfilRepository.ObterPorNome("OPERADOR");
            usuario.PerfilId = perfil.Id;

            #endregion

            #region Gravar o usuário no banco de dados

            _usuarioRepository.Add(usuario);

            #endregion

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
            #region Consultar o usuário no banco de dados através do email e da senha

            var usuario = _usuarioRepository.Find(dto.Email, SHA256Helper.Encrypt(dto.Senha));

            #endregion

            #region Verificando se o usuário não foi encontrado

            if (usuario == null)
                throw new ApplicationException("Acesso negado. Usuário inválido.");

            #endregion

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
