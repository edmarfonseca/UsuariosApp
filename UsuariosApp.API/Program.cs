using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Data.Repositories;
using UsuariosApp.Infra.Security.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Injeções de dependência

builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPerfilRepository, PerfilRepository>();
builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();

#endregion

#region Configuração do CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("UsuariosPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("UsuariosPolicy");

app.UseAuthorization();
app.MapControllers();
app.Run();

//tornando a classe Program pública
public partial class Program { }
