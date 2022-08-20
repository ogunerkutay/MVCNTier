using AutoMapper;
using MVCNTier.BLL.Models.DTOs;
using MVCNTier.BLL.Models.VMs;
using MVCNTier.Core.Entities;
using MVCNTier.Core.Entities.Enums;
using MVCNTier.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Services.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }
        public async Task Create(CreateGenreDTO model)
        {

            var genre = mapper.Map<Genre>(model);
            await genreRepository.Create(genre);
        }

        public async Task Delete(int id)
        {
            var genre = await genreRepository.GetWhere(x => x.Id == id);
            genreRepository.Delete(genre);
        }

        public async Task<UpdateGenreDTO> GetById(int id)
        {
            var genre = await genreRepository.GetFilteredFirstOrDefault(
                selector: x => new UpdateGenreDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            },
            expression: x => x.Id == id && x.Status != Status.Passive);
            return genre;
        }

        public async Task<List<GetGenreVM>> GetGenres()
        {
            var genres = await genreRepository.GetFilteredList(
            selector: x => new GetGenreVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            },
            expression: x => x.Status != Status.Passive,orderBy: x=> x.OrderBy(x => x.Name));
            return genres;
        }

        public bool Update(UpdateGenreDTO model)
        {
            var genre = mapper.Map<Genre>(model);
            bool result = genreRepository.Update(genre);
            return result;
        }


    }
}
