using Application.Contracts.Requests;
using Application.Contracts.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Commands.CustomerManager
{
    public class CreateCustomerCommand : IRequest<long>
    {
        public CustomerRequestCreateModel CustomerRequestCreateModel { get; }

        public CreateCustomerCommand(CustomerRequestCreateModel customerRequestCreateModel) 
        {
            CustomerRequestCreateModel = customerRequestCreateModel;
        }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, long>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreateCustomerCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = _mapper.Map<Customer>(request.CustomerRequestCreateModel);

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync(cancellationToken);

                return customer.Id;
            }
        }
    }   
}
