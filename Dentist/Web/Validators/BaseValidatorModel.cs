using FluentValidation;
using Web.Models;

namespace Web.Validators;

public class BaseValidatorModel  <TModel> : AbstractValidator<TModel> where TModel : BaseModel
{
    
}