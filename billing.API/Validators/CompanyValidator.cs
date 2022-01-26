using billing.Data.DTOs.Masters;
using billing.Data.Generics.General;
using billing.Data.Resources.Labels;
using billing.Data.Resources.Validations;
using billing.Service.Masters.Company;
using FluentValidation;

using System.Threading.Tasks;

namespace billing.API.Validators
{
    public class CompanyValidator : AbstractValidator<CompanyDTO>
    {
        private readonly ICompanyService _service;
        public CompanyValidator(ICompanyService service)
        {
            _service = service;

            RuleFor(m => m.Name)
                .NotEmpty().WithMessage(CommonValidationMessages.USER_NAME_REQUIRED)
                .MustAsync(async (entity, value, c) => await CheckDuplication(new DuplicateValidation
                {
                    Value = entity.Name,
                    Label = "NAME",
                    ColumnName = "name",
                    Identifier = entity.UId
                }))
                .WithMessage(CommonValidationMessages.CUSTOM_VALUE_DUPLICATION.Replace("{{Label}}", CommonLabels.ResourceManager.GetString("NAME")));
        }

        public async Task<bool> CheckDuplication(DuplicateValidation input)
        {
            var result = await _service.CheckDuplication(input);
            return result.Success;
        }
    }
}
