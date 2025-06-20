using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        var appAssembly = AppDomain.CurrentDomain.GetAssemblies();
        services.AddScoped<IRestaurantsService, RestaurantsService>();
        services.AddAutoMapper(appAssembly);
        services.AddValidatorsFromAssemblies(appAssembly).AddFluentValidationAutoValidation();
    }
}
