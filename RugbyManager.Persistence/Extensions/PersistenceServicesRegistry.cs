using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RugbyManager.Shared.Helpers;

namespace RugbyManager.Persistence.Extensions
{
    public static class PersistenceServicesRegistry
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<RugbyManagerContext>(options =>
                options.UseSqlServer(
                    ConfigurationHelper.config.GetSection("ConnectionStrings:DefaultConnection").Value));
        }
    }
}
