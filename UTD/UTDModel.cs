using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Models
{
    public abstract class UTDModel
    {
        public Guid Id = Guid.NewGuid();
        public DateTime Created = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
