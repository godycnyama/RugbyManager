using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RugbyManager.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
