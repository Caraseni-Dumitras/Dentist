using AutoMapper;
using Core.Entities;
using Web.Areas.Admin.Models.DoctorModels;
using Web.Areas.Admin.Models.ProcedureModels;

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
        
        CreateMap<Procedure, ProcedureModel>();
        CreateMap<ProcedureModel, Procedure>();
    }
}