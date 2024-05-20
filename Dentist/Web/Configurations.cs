using Web.Areas.Admin.Factories;

namespace Web;

public static class Configurations
{
    public static void ConfigureWeb(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(Program));
        
        //register admin factories
        serviceCollection.AddScoped<IDoctorModelFactory, DoctorModelFactory>();
    }
}