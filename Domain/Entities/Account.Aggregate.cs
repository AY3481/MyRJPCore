using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Account: IAggregateRoot
    {
        public Transaction AddTransaction(int initialCredit)
        {
            var oTransaction = new Transaction() { AccountId = this.Id, Credit = initialCredit };

            this.Transactions.Add(oTransaction);

            return oTransaction;
        }
    }
}
