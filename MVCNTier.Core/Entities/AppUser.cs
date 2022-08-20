using Microsoft.AspNetCore.Identity;
using MVCNTier.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.Core.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        //Identity modification
        public string FullName { get; set; }
        public string ImagePath { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public Status Status { get; set; }

        //relations

        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
