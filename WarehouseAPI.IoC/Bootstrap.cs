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
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}
