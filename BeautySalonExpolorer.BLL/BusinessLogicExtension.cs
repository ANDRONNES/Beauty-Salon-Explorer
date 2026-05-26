using BeautySalonExpolorer.BLL.Interfaces;
using BeautySalonExpolorer.BLL.Services;
using BeautySalonExpolorer.BLL.Validators;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

public static class BusinessLogicExtension
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddScoped<ISalonService, SalonService>();
        services.AddValidatorsFromAssemblyContaining<UpdateSalonDtoValidator>();
        return services;
    }
}