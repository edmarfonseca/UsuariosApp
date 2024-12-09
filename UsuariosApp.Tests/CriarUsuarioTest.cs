using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Dtos;
using Xunit;

namespace UsuariosApp.Tests
{
    /// <summary>
    /// Testes para o serviço de criação de usuário da API
    /// </summary>
    public class CriarUsuarioTest
    {
        [Fact]
        public async Task Criar_Usuario_Com_Sucesso_Test()
        {
            var faker = new Faker("pt_BR");

            var request = new CriarUsuarioRequestDto
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste2024"
            };

            var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory<Program>().CreateClient();
            var response = await client.PostAsync("/api/usuarios/criar", json);

            response.StatusCode
                .Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Nao_Permitir_Email_Duplicado_Test()
        {
            var faker = new Faker("pt_BR");

            var request = new CriarUsuarioRequestDto
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste2024"
            };

            var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //cadastrando o usuário pela primeira vez
            var client = new WebApplicationFactory<Program>().CreateClient();
            await client.PostAsync("/api/usuarios/criar", json);

            //cadastrando o mesmo usuário (com o mesmo email)
            var response = await client.PostAsync("/api/usuarios/criar", json);

            //verificando o status do retorno
            response.StatusCode
                .Should().Be(HttpStatusCode.UnprocessableContent);

            //verificando a mensagem obtida da API
            var mensagem = await response.Content.ReadAsStringAsync();
            mensagem
                .Should().Contain("O email informado já está cadastrado, tente outro.");
        }
    }
}
