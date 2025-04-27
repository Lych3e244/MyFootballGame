using MyFootballGame.Other.Application.Interfaces;
using MyFootballGame.Other.Application.Services;
using MyFootballGame.Other.Domain.Interfaces;
using MyFootballGame.Other.Infrastructure.Repositories;

namespace MyFootballGame.Other.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ILeagueService, LeagueService>();
            services.AddTransient<ISeasonService, SeasonService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();
            services.AddTransient<ISeasonRepository, SeasonRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IMatchService, MatchService>();
            services.AddTransient<IMatchRepository, MatchRepository>();
            return services;
        }
    }
}