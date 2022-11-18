using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Responses
{
    public class CustomerTransactionsResponseModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public int? Balance { get; set; }
        public virtual ICollection<TransactionResponseModel> Transactions { get; set; }
    }
}
