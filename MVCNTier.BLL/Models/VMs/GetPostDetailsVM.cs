using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Models.VMs
{
    public class GetPostDetailsVM
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public string Image { get; set; }
        public string AuthorFullName { get; set; }
        public string AuthorImage { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        
        public List<GetCommentsVM> Comments { get; set; }
    }
}
