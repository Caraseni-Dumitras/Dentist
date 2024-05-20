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

    public DoctorModelFactory(
        IMapper mapper, 
        IDoctorService doctorService)
    {
        _mapper = mapper;
        _doctorService = doctorService;
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