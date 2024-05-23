using FluentValidation.AspNetCore;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.Validators;
using Web.Factories;

namespace Web;

public static class Configurations
{
    public static void ConfigureWeb(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(Program));
        serviceCollection.AddRazorPages();
        
        serviceCollection.AddAuthorization(options =>
        {
            options.AddPolicy("ClientPolicy", policy =>
                policy.RequireRole("Client", "Admin"));
            options.AddPolicy("AdminPolicy", policy =>
                policy.RequireRole("Admin"));
        });
        
        serviceCollection.AddControllersWithViews()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(BaseAdminValidatorModel<>)));
        
        //register admin factories
        serviceCollection.AddScoped<IDoctorModelFactory, DoctorModelFactory>();
        serviceCollection.AddScoped<IProcedureModelFactory, ProcedureModelFactory>();
        serviceCollection.AddScoped<IBaseAdminModelFactory, BaseAdminModelFactory>();
        serviceCollection.AddScoped<IAppointmentModelFactory, AppointmentModelFactory>();

        //register base factories
        serviceCollection.AddScoped<IBaseModelFactory, BaseModelFactory>();
    }
}