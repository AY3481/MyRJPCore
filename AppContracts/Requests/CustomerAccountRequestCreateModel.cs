using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Requests
{
    public class CustomerAccountRequestCreateModel
    {
        public long CustomerId { get; set; }
        public int InitialCredit { get; set; }
    }
}
