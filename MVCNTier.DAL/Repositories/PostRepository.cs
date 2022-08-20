using MVCNTier.Core.Entities;
using MVCNTier.Core.IRepositories;
using MVCNTier.DAL;
using MVCNTier.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }
}