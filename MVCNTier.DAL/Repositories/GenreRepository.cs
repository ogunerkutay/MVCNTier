using MVCNTier.Core.Entities;
using MVCNTier.Core.IRepositories;
using MVCNTier.DAL;
using MVCNTier.DAL.Repositories;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    public GenreRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }
}