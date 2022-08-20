using MVCNTier.BLL.Models.DTOs;
using MVCNTier.BLL.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Services.GenreService
{
    public interface IGenreService
    {
        Task Create(CreateGenreDTO model);
        bool Update(UpdateGenreDTO model);

        Task Delete(int id);
        Task<UpdateGenreDTO> GetById(int id);
        Task<List<GetGenreVM>> GetGenres();
    }
}
