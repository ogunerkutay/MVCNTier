using MVCNTier.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.Core.Entities
{
    public class Post:IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }

        public Status Status { get; set; }


        //relations

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }

    }
}
