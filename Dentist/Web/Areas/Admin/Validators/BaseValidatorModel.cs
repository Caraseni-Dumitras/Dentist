using FluentValidation;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Validators;

public class BaseValidatorModel <TModel> : AbstractValidator<TModel> where TModel : BaseModel
{
    
}