using Core.Entities;
using Web.Areas.Admin.Models;
using Web.Areas.Admin.Models.DoctorModels;

namespace Web.Areas.Admin.Factories;

public interface IDoctorModelFactory
{
    Task<DoctorAdminModel> PrepareDoctorModelAsync(DoctorAdminModel adminModel, Doctor doctor);
    Task<DoctorListAdminModel> PrepareDoctorModelListAsync(DoctorAdminSearchModel model);
}