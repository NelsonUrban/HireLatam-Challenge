using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

namespace HireLatam.Application;

public static class AssemblyReferences
{
    public static IServiceCollection Application(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(AssemblyReferences).Assembly);
        services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
        return services;
    }
}
