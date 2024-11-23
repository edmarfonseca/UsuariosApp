using UsuariosApp.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjection();

var userPolicy = "UsuariosPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(userPolicy, builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(userPolicy);

app.UseAuthorization();
app.MapControllers();
app.Run();

//tornando a classe Program pública
public partial class Program { }