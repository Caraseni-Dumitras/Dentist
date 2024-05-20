using Core.Entities;
using Web.Areas.Admin.Models;
using Web.Areas.Admin.Models.DoctorModels;

namespace Web.Areas.Admin.Factories;

public interface IDoctorModelFactory
{
    Task<DoctorModel> PrepareDoctorModelAsync(DoctorModel model, Doctor doctor);
    Task<DoctorListModel> PrepareDoctorModelListAsync(DoctorSearchModel model);
}