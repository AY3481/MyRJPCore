using Domain.Base;
using System.Collections.Generic;


namespace Domain.Entities
{
    public partial class Customer: BaseEntity
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
        }

        public string Name { get; set; }
        public string SurName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
