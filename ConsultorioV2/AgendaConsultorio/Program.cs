using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Configura o ServiceProvider
        var serviceProvider = ConfigureServices();

        // Obtém o MenuPrincipal a partir do ServiceProvider e executa
        using (var scope = serviceProvider.CreateScope())
        {
            var menuPrincipal = scope.ServiceProvider.GetRequiredService<MenuPrincipal>();
            menuPrincipal.Exibir();
        }
    }

    private static ServiceProvider ConfigureServices()
    {
        // Configuração dos serviços
        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory()) // Diretório base
        .AddJsonFile("appsettings.json") // Carrega o appsettings.json
        .Build();

        // Registra o DbContext
        services.AddDbContext<ConsultorioContext>(options =>
            options.UseNpgsql("ConsultorioConnection"));

        // Registra os menus
        services.AddTransient<MenuPrincipal>();
        services.AddTransient<MenuCadastroPaciente>();
        services.AddTransient<MenuAgenda>();

        // Retorna o ServiceProvider configurado
        return services.BuildServiceProvider();
    }
}
