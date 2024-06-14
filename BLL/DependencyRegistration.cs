using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BLL
{
    public class DependencyRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IRaceService, RaceService>();
            services.AddScoped<ISubRaceService, SubRaceService>();
            services.AddScoped<IBackgroundService, BackgroundService>();
            services.AddScoped<ICharacterClassService, CharacterClassService>();
            services.AddScoped<ICharacterSubClassService, CharacterSubClassService>();
            services.AddScoped<IAbilityScoreService, AbilityScoreService>();

            DAL.DependencyRegistration.RegisterRepositories(services);
        }
    }
}
