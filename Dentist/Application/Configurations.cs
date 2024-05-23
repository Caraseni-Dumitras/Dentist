using System.Configuration;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Configurations
{
    public static void ConfigureApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDoctorService, DoctorService>();
        serviceCollection.AddScoped<IProcedureService, ProcedureService>();
        serviceCollection.AddScoped<IDoctorProcedureService, DoctorProcedureService>();
        serviceCollection.AddScoped<IAppointmentService, AppointmentService>();

        serviceCollection.AddTransient<IEmailService, EmailService>();
    }
}