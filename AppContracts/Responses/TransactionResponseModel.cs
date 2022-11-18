using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Responses
{
    public class TransactionResponseModel
    {
        public long Id { get; set; }
        public int Credit { get; set; }
        public long AccountId { get; set; }

        public virtual AccountResponseModel Account { get; set; }
    }
}
