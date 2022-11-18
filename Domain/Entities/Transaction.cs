using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Transaction: BaseEntity
    { 
        public int Credit { get; set; }
        public long AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
