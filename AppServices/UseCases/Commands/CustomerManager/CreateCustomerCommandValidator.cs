using Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.CustomerManager
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator(IApplicationDbContext _context)
        {
            RuleFor(v => v.CustomerRequestCreateModel)
              .NotNull();

            RuleFor(v => v.CustomerRequestCreateModel.Id)
               .Equal(0).WithMessage("Id should be equal 0.");

            RuleFor(v => v.CustomerRequestCreateModel.Name)
               .NotEmpty().WithMessage("Name is required");

            RuleFor(v => v.CustomerRequestCreateModel.SurName)
               .NotEmpty().WithMessage("SurName is required");
        }
    }
}
