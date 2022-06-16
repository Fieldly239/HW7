using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrudCustom.Shared
{
    public class FeedBack
    {
        public int Id { get; set; }
        
        public string Description { get; set; } = string.Empty;
        public Vote? Vote { get; set; }
        public int VoteId { get; set; }
        public Appilcation? Appilcation { get; set; }
        public int AppilcationId { get; set; }

    }
}
