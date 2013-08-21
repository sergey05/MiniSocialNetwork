using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class RePost:Post
    {
        public virtual User Owner { get; set; }
    }
}
