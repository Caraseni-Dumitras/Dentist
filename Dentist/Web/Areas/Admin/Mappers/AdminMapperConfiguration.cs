using AutoMapper;
using Core.Entities;
using Web.Areas.Admin.Models;
using Web.Areas.Admin.Models.DoctorModels;

namespace Web.Areas.Admin.Mappers;

public class AdminMapperConfiguration: Profile
{
    public AdminMapperConfiguration()
    {
        CreateConfigMaps();
    }

    protected void CreateConfigMaps()
    {
        CreateMap<Doctor, DoctorModel>();
    }
}