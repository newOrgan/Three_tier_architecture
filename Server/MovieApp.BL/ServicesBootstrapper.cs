using Microsoft.Extensions.DependencyInjection;
using MovieApp.BL.Interfaces;
using MovieApp.BL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace MovieApp.BL
{
    public static class ServicesBootstrapper
    {
        public static void ServicesDI (this IServiceCollection services)
        {
            services.AddTransient<IActorService, ActorService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IShowTimeService, ShowTimeService>();
        }
    }
}
