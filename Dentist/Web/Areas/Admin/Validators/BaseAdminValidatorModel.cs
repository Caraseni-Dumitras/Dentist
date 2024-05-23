using FluentValidation;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Validators;

public class BaseAdminValidatorModel <TModel> : AbstractValidator<TModel> where TModel : BaseAdminModel
{
    
}