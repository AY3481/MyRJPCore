using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Requests
{
    public class CustomerRequestCreateModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }

        //public virtual ICollection<Account> Accounts { get; set; }
    }
}
