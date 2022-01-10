using billing.Data.DTOs.Masters;
using billing.Data.Generics.General;
using billing.Data.Resources.Labels;
using billing.Data.Resources.Validations;
using billing.Service.Masters.Customer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billing.API.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerDTO>
    {
        private readonly ICustomerService _service;
        public CustomerValidator(ICustomerService service)
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
