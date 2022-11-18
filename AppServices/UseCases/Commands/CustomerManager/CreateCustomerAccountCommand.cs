using Application.Contracts.Requests;
using Application.Contracts.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Commands.CustomerManager
{
    public class CreateCustomerAccountCommand : IRequest<long>
    {
        public CustomerAccountRequestCreateModel CustomerAccountRequestCreateModel { get; }

        public CreateCustomerAccountCommand(CustomerAccountRequestCreateModel customerAccountRequestCreateModel) 
        {
            CustomerAccountRequestCreateModel = customerAccountRequestCreateModel;
        }

        public class CreateCustomerAccountCommandHandler : IRequestHandler<CreateCustomerAccountCommand, long>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreateCustomerAccountCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<long> Handle(CreateCustomerAccountCommand request, CancellationToken cancellationToken)
            {
                var initialCredit = request.CustomerAccountRequestCreateModel.InitialCredit;
                var customerId = request.CustomerAccountRequestCreateModel.CustomerId;
                var customer = await _context.Customers.FindAsync(customerId);

                if (customer == null) {
                    throw new Exception("Customer with ID: " + customerId + " not found!");
                }

                var account = customer.AddAccount(initialCredit);
                
                await _context.SaveChangesAsync(cancellationToken);

                return account.Id;
            }
        }
    }   
}
