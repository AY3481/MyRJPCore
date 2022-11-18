using Application.Contracts.Responses;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetCustomerTransactionsQuery : IRequest<List<CustomerTransactionsResponseModel>>
    {
        public long CustomerID { get; }

        public GetCustomerTransactionsQuery(long customerId)
        {
            CustomerID = customerId;
        }

        public class GetCustomerTransactionsQueryHandler : IRequestHandler<GetCustomerTransactionsQuery, List<CustomerTransactionsResponseModel>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetCustomerTransactionsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CustomerTransactionsResponseModel>> Handle(GetCustomerTransactionsQuery request, CancellationToken cancellationToken)
            {
                var customerId = request.CustomerID;
                var CustomerTransactions = await _context.Customers
                    .Include(x => x.Accounts).ThenInclude(y => y.Transactions)
                    //.Where(x => x.Id == customerId)
                    .Select(o => new CustomerTransactionsResponseModel()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        SurName = o.SurName,
                        Balance = o.Accounts.SelectMany(s => s.Transactions).Sum(x => x.Credit),
                        Transactions = _mapper.Map<List<TransactionResponseModel>>(o.Accounts.SelectMany(s => s.Transactions).ToList())
                    })
                    .ToListAsync();
                    //.FirstOrDefaultAsync();

                return CustomerTransactions;
            }
        }
    }
}
