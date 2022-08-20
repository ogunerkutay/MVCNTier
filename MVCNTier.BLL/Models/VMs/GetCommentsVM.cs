using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Models.VMs
{
    public class GetCommentsVM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
