using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Requests
{
    public class AccountRequestModel
    {
        public string? Number { get; set; }
        public long CustomerId { get; set; }

        //public virtual Customer Customer { get; set; }
        //public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
