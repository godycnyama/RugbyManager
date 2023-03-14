using Microsoft.Extensions.DependencyInjection;
using RugbyManager.Services.Players;
using RugbyManager.Services.Stadiums;
using RugbyManager.Services.Teams;

namespace RugbyManager.Services.Extensions
{
    public static class RugbyManagerServicesRegistry
    {
        public static void AddRugbyManagerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPlayersService, PlayersService>();
            serviceCollection.AddScoped<IStadiumsService, StadiumsService>();
            serviceCollection.AddScoped<ITeamsService, TeamsService>();
        }
    }
}
