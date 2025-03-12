using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;

namespace Pokedex.Infrastructure.Persistence
{
    //Extension Method - Decorator
    public static class ServiceRegistration
    {
       
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddTransient<IPokeService, PokeService>();
            services.AddTransient<IRegiService, RegiService>();
            services.AddTransient<ITypeService, TypeService>();
            #endregion
        }
    }
}
