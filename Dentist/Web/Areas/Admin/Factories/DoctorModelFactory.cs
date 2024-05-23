using Application.Services;
using AutoMapper;
using Core.Entities;
using Web.Areas.Admin.Extensions;
using Web.Areas.Admin.Models.DoctorModels;

namespace Web.Areas.Admin.Factories;

public class DoctorModelFactory : IDoctorModelFactory
{
    private readonly IMapper _mapper;
    private readonly IDoctorService _doctorService;
    private readonly IBaseAdminModelFactory _baseAdminModelFactory;
    private readonly IDoctorProcedureService _doctorProcedureService;

    public DoctorModelFactory(
        IMapper mapper, 
        IDoctorService doctorService, 
        IBaseAdminModelFactory baseAdminModelFactory, 
        IDoctorProcedureService doctorProcedureService)
    {
        _mapper = mapper;
        _doctorService = doctorService;
        _baseAdminModelFactory = baseAdminModelFactory;
        _doctorProcedureService = doctorProcedureService;
    }

    public async Task<DoctorAdminModel> PrepareDoctorModelAsync(DoctorAdminModel adminModel, Doctor doctor)
    {
        if (adminModel is null)
        {
            adminModel = new DoctorAdminModel();
        }
        
        if (doctor is not null)
        {
            adminModel = _mapper.Map<DoctorAdminModel>(doctor);
            adminModel.SelectedProceduresIds =
                (await _doctorProcedureService.GetAllDoctorProceduresByDoctorIdAsync(doctor.Id)).Select(it => it.ProcedureId)
                .ToList();
        }
        
        await _baseAdminModelFactory.PrepareAvailableProceduresAsync(adminModel.AvailableProcedures);
        
        foreach (var procedureItem in adminModel.AvailableProcedures)
        {
            procedureItem.Selected = int.TryParse(procedureItem.Value, out var procedureId)
                                     && adminModel.SelectedProceduresIds.Contains(procedureId);
        }

        return adminModel;
    }

    public async Task<DoctorListAdminModel> PrepareDoctorModelListAsync(DoctorAdminSearchModel adminSearchModel)
    {
        if (adminSearchModel == null)
            throw new ArgumentNullException(nameof(adminSearchModel));

        var doctors = await _doctorService.GetAllDoctors();

        var model = await new DoctorListAdminModel().PrepareToGridAsync(adminSearchModel, doctors, () =>
        {
            return doctors.Select(doctor =>
            {
                var doctorModel = _mapper.Map<DoctorAdminModel>(doctor);
                return doctorModel;
            });
        });

        return model;
    }
}