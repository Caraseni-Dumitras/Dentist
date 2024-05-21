using FluentValidation.AspNetCore;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.Validators;

namespace Web;

public static class Configurations
{
    public static void ConfigureWeb(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(Program));
        
        serviceCollection.AddControllersWithViews()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(BaseValidatorModel<>)));
        
        //register admin factories
        serviceCollection.AddScoped<IDoctorModelFactory, DoctorModelFactory>();
    }
}