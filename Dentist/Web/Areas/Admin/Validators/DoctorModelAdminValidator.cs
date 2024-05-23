using FluentValidation;
using Web.Areas.Admin.Models.DoctorModels;

namespace Web.Areas.Admin.Validators;

public class DoctorModelAdminValidator : BaseAdminValidatorModel<DoctorAdminModel>
{
    public DoctorModelAdminValidator()
    {
        RuleFor(it => it.FirstName)
            .NotEmpty()
            .WithMessage("First Name can't be empty");
        
        RuleFor(it => it.LastName)
            .NotEmpty()
            .WithMessage("Last Name can't be empty");
        
        RuleFor(it => it.Email)
            .NotEmpty()
            .WithMessage("User Name can't be empty")
            .EmailAddress()
            .WithMessage("Provide a valid email address");

        RuleFor(it => it.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number can't be empty");
        
        RuleFor(model => model.SelectedProceduresIds)
            .Must(procedureIds => procedureIds.Count <= 3)
            .WithMessage("A doctor cannot have more than 3 procedures.");
    }   
}