using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DepedencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DepedencyInjection).Assembly;

        services.AddMediatR(configuration => 
            configuration.RegisterServicesFromAssemblies(assembly));

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }

}
