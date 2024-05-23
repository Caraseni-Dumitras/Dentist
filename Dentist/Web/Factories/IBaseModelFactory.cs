using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Models;

namespace Web.Factories;

public interface IBaseModelFactory
{
    Task PrepareAvailableProceduresAndDoctorsAsync(AppointmentModel model);
    Task<List<SelectListItem>> PrepareAvailableDoctorsAsync(int procedureId, DateTime appointmentDateTimeUtc);
}