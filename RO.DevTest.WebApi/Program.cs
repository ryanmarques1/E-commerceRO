using Microsoft.AspNetCore.Identity;
using RO.DevTest.Application;
using RO.DevTest.Infrastructure.IoC;
using RO.DevTest.Persistence.Repositories;
using RO.DevTest.Application.Contracts.Persistence.Repositories;
using RO.DevTest.Persistence.IoC;
namespace RO.DevTest.WebApi;
using RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;

public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.InjectPersistenceDependencies(builder.Configuration)
            .InjectInfrastructureDependencies();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        
        // Add Mediatr to program
        // Adiciona MediatR registrando os assemblies corretos
            builder.Services.AddMediatR(cfg =>
            {
            cfg.RegisterServicesFromAssemblies(
                typeof(CreateProductCommandHandler).Assembly,
                typeof(ApplicationLayer).Assembly);
            });

        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if(app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
