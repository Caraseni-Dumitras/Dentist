using FluentValidation;
using Web.Areas.Admin.Models.DoctorModels;

namespace Web.Areas.Admin.Validators;

public class DoctorModelValidator : BaseValidatorModel<DoctorModel>
{
    public DoctorModelValidator()
    {
        RuleFor(it => it.UserName)
            .NotEmpty()
            .WithMessage("User Name can't be empty");
        
        RuleFor(it => it.Email)
            .NotEmpty()
            .WithMessage("User Name can't be empty")
            .EmailAddress()
            .WithMessage("Provide a valid email address");

        RuleFor(it => it.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number can't be empty");
    }   
}