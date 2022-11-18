using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Responses
{
    public class AccountResponseModel
    {
        public long Id { get; set; }
        public string? Number { get; set; }
        public long CustomerId { get; set; }

        public virtual CustomerResponseModel Customer { get; set; }
        public virtual ICollection<TransactionResponseModel> Transactions { get; set; }
    }
}
