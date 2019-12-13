using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TESTFamifedScreens.DAL.Entities;
using TESTFamifedScreens.DAL.Repositories;

namespace TESTFamifedScreens.DAL.Extensions
{
    public static class RepositoryCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        { 
        //DAL repo inladen
        services.AddTransient<IGenericRepository<FlowStatus>, GenericRepository<FlowStatus>>();
            services.AddTransient<IGenericRepository<FoodOption>, GenericRepository<FoodOption>>();
            services.AddTransient<IGenericRepository<FoodRequest>, GenericRepository<FoodRequest>>();
            services.AddTransient<IGenericRepository<Person>, GenericRepository<Person>>();

            return services;
    }
    }
}
