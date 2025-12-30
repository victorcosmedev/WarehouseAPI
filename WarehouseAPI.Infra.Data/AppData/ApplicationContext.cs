using Microsoft.EntityFrameworkCore;

namespace WarehouseAPI.Infra.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
