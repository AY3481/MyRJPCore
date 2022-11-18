using Domain.Interfaces;
using FluentValidation;
using System;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Commands.CustomerManager
{
    public class CreateCustomerAccountCommandValidator : AbstractValidator<CreateCustomerAccountCommand>
    {
        public CreateCustomerAccountCommandValidator(IApplicationDbContext _context)
        {
            RuleFor(v => v.CustomerAccountRequestCreateModel)
              .NotNull();

            //RuleFor(v => v.customerAccountRequestCreateModel.CustomerId)
            //   .GreaterThan(0).WithMessage("CustomerId should be greater than 0.")
            //   .MustAsync(async (cmd, id, token) =>
            //    {
            //        return await _context.Customers.AnyAsync(x => x.Id == id, token);
            //    })
            //    .WithMessage("This CustomerId does not exist.");
        }
    }
}
