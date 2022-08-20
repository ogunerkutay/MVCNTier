using MVCNTier.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.Core.Entities
{
    public interface IBaseEntity
    {
        public DateTime CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }

        public Status Status { get; set; }

    }
}
