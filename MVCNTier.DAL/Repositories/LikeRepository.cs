using MVCNTier.Core.Entities;
using MVCNTier.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.DAL.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
