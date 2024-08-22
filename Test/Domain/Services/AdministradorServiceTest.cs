using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.Services;
using MinimalAPI.Infrastructure.DB;

namespace Test.Domain.Services
{
    [TestClass]
    public class AdministradorServiceTest
    {
        private DbContexto CriarContextoTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
            //Configurar o ConfigurationBuilder
            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            //Obter a string de conexão
            var connectionString = configuration.GetConnectionString("ConexaoPadrao");

            //Configurar o DbContextOptionsBuilder
            var options = new DbContextOptionsBuilder<DbContexto>()
                .UseSqlServer(connectionString).Options;

            return new DbContexto(options);
        }
        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            var context = CriarContextoTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores;");

            var adm = new Administrador();
            adm.Id = 1;
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";

            var admService = new AdministradorService(context);

            admService.Incluir(adm);

            Assert.AreEqual(1, admService.Todos(1).Count());
        }

        [TestMethod]
        public void TestandoBuscarAdministradorPorId()
        {
            var context = CriarContextoTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores;");

            var adm = new Administrador();
            adm.Id = 1;
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";

            var admService = new AdministradorService(context);

            admService.Incluir(adm);
            var admBuscadoPorId = admService.BuscaPorId(adm.Id);

            Assert.AreEqual(1, admBuscadoPorId.Id);
        }
    }
}