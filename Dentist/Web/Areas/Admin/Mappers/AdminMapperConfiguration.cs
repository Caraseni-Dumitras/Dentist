using AutoMapper;
using Core.Entities;
using Web.Areas.Admin.Models.DoctorModels;

namespace Web.Areas.Admin.Mappers;

public class AdminMapperConfiguration: Profile
{
    public AdminMapperConfiguration()
    {
        CreateConfigMaps();
    }

    private void CreateConfigMaps()
    {
        CreateMap<Doctor, DoctorModel>();
        CreateMap<DoctorModel, Doctor>();
    }
}