using Web.Areas.Admin.Models.AppointmentModels;

namespace Web.Areas.Admin.Factories;

public interface IAppointmentModelFactory
{ 
    Task<AppointmentSearchModel> PrepareAppointmentSearchModelAsync(AppointmentSearchModel searchModel);
    Task<AppointmentListModel> PrepareAppointmentListModelAsync(AppointmentSearchModel searchModel);
}