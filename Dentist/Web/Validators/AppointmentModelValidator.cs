using FluentValidation;
using Web.Models;

namespace Web.Validators;

public class AppointmentModelValidator : BaseValidatorModel<AppointmentModel>
{
    public AppointmentModelValidator()
    {
        RuleFor(it => it.SelectedProcedureId)
            .GreaterThan(0)
            .WithMessage("You must select a procedure!");
        
        RuleFor(it => it.SelectedDoctorId)
            .GreaterThan(0)
            .WithMessage("You must select a doctor!");
    }
}