using MVCNTier.BLL.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Services.PostService
{
    public interface IPostService
    {
        Task<List<GetPostVM>> GetPosts();
        Task<List<GetPostDetailsVM>> GetPostDetails(int id);


    }
}
