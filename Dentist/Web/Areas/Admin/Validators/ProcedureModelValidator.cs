using FluentValidation;
using Web.Areas.Admin.Models.ProcedureModels;

namespace Web.Areas.Admin.Validators;

public class ProcedureModelValidator : BaseValidatorModel<ProcedureModel>
{
    public ProcedureModelValidator()
    {
        RuleFor(it => it.Name)
            .NotEmpty()
            .WithMessage("Procedure Name can't be empty");

        RuleFor(it => it.CabinetNumber)
            .NotEmpty()
            .WithMessage("Cabinet number can't be empty");
    } 
}