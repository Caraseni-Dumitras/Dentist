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
    private readonly IBaseAdminModelFactoy _baseAdminModelFactory;
    private readonly IDoctorProcedureService _doctorProcedureService;

    public DoctorModelFactory(
        IMapper mapper, 
        IDoctorService doctorService, 
        IBaseAdminModelFactoy baseAdminModelFactory, 
        IDoctorProcedureService doctorProcedureService)
    {
        _mapper = mapper;
        _doctorService = doctorService;
        _baseAdminModelFactory = baseAdminModelFactory;
        _doctorProcedureService = doctorProcedureService;
    }

    public async Task<DoctorModel> PrepareDoctorModelAsync(DoctorModel model, Doctor doctor)
    {
        if (model is null)
        {
            model = new DoctorModel();
        }
        
        if (doctor is not null)
        {
            model = _mapper.Map<DoctorModel>(doctor);
            model.SelectedProceduresIds =
                (await _doctorProcedureService.GetAllDoctorProceduresByDoctorIdAsync(doctor.Id)).Select(it => it.ProcedureId)
                .ToList();
        }
        
        await _baseAdminModelFactory.PrepareAvailableProceduresAsync(model.AvailableProcedures);
        
        foreach (var procedureItem in model.AvailableProcedures)
        {
            procedureItem.Selected = int.TryParse(procedureItem.Value, out var procedureId)
                                     && model.SelectedProceduresIds.Contains(procedureId);
        }

        return model;
    }

    public async Task<DoctorListModel> PrepareDoctorModelListAsync(DoctorSearchModel searchModel)
    {
        if (searchModel == null)
            throw new ArgumentNullException(nameof(searchModel));

        var doctors = await _doctorService.GetAllDoctors();

        var model = await new DoctorListModel().PrepareToGridAsync(searchModel, doctors, () =>
        {
            return doctors.Select(doctor =>
            {
                var doctorModel = _mapper.Map<DoctorModel>(doctor);
                return doctorModel;
            });
        });

        return model;
    }
}