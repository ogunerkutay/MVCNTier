using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCNTier.BLL.Models.DTOs;
using MVCNTier.BLL.Models.VMs;
using MVCNTier.BLL.Services.PostService;
using MVCNTier.Core.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MVCNTier.Presentation.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles="Member")]
    [Authorize(Policy = "UserClaimAgePolicy")]
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        string baseUrl = "https://localhost:44358/api/";

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            string method = "Genre/GetAllGenre";
            var response = await client.GetAsync(baseUrl + method);
            string msg = await response.Content.ReadAsStringAsync();
            List<GetGenreVM> listGenre = JsonConvert.DeserializeObject<List<GetGenreVM>>(msg);
            return View(listGenre);
        }

        [HttpPost]
        public IActionResult Index(List<GetGenreVM> listGenre)
        {
            return PartialView("PartialIndex", listGenre);
        }


        public IActionResult AddGenre()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddGenre(CreateGenreDTO genreDTO)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                string method = "Genre/AddGenre";

                var myContent = JsonConvert.SerializeObject(genreDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await client.PostAsync(baseUrl + method, byteContent);

                return RedirectToAction("Index", "Home", new { area = "Member" });
            }
            return View();
        }


        public async Task<IActionResult> UpdateGenre(int id)
        {
            HttpClient client = new HttpClient();
            string method = "Genre/GetGenreById/";
            var response = await client.GetAsync(baseUrl + method + id);
            string msg = await response.Content.ReadAsStringAsync();
            UpdateGenreDTO genre = JsonConvert.DeserializeObject<UpdateGenreDTO>(msg);
            return View(genre);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateGenre(UpdateGenreDTO genreDTO)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                string method = "Genre/UpdateGenre";

                var myContent = JsonConvert.SerializeObject(genreDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await client.PutAsync(baseUrl + method, byteContent);

                return RedirectToAction("Index", "Home", new { area = "Member" });
            }
            return View();
        }


    }
}
