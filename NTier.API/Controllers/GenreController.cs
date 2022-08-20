using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCNTier.BLL.Models.DTOs;
using MVCNTier.BLL.Models.VMs;
using MVCNTier.BLL.Services.AppUserService;
using MVCNTier.BLL.Services.GenreService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NTier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;
        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        [Route("GetAllGenre")]
        public async Task<IActionResult> GetAllGenre()
        {
            List<GetGenreVM> genres = await genreService.GetGenres();
            return Ok(genres);
        }


        [HttpGet]
        [Route("GetGenreById/{id:int}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            UpdateGenreDTO genre = await genreService.GetById(id);
            return Ok(genre);
        }

        [HttpPost]
        [Route("AddGenre")]
        public async Task<IActionResult> AddGenre(CreateGenreDTO genreDTO)
        {
            await genreService.Create(genreDTO);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateGenre")]
        public IActionResult UpdateGenre(UpdateGenreDTO genreDTO)
        {
            genreService.Update(genreDTO);
            return Ok(new {result = true});
        }




    }
}