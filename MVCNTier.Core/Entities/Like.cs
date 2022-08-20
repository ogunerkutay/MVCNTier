﻿using MVCNTier.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.Core.Entities
{
    public class Like:IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }

        public Status Status { get; set; }

        //relations

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }


    }
}
