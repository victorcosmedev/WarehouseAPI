using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarehouseAPI.Domain.Interfaces;
using WarehouseAPI.Infra.Data.AppData;

namespace WarehouseAPI.IoC;

public class Bootstrap
{
    public static void AddIoC(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = string.Empty;
        services.AddDbContext<ApplicationContext>(opt =>
        {
            opt.UseNpgsql(connectionString);
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}
