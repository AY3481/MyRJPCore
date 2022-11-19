using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Customer: IAggregateRoot
    {
        public Account AddAccount(int initialCredit)
        {
            var oAccount = new Account() { CustomerId = this.Id, Number = "Acct-" + new Random().Next(999999) };

            if (initialCredit > 0)
            {
                oAccount.AddTransaction(initialCredit);
            }
            
            this.Accounts.Add(oAccount);

            return oAccount;
        }
    }
}
