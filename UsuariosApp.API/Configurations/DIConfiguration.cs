﻿using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Data.Repositories;
using UsuariosApp.Infra.Security.Services;

namespace UsuariosApp.API.Configurations
{
    public static class DIConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IUsuarioPerfilRepository, UsuarioPerfilRepository>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();
        }
    }
}