using Microsoft.EntityFrameworkCore;
using MVCNTier.BLL.Models.VMs;
using MVCNTier.Core.Entities.Enums;
using MVCNTier.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Services.PostService
{
    public class PostService : IPostService
    {

        private readonly IPostRepository postRepository;
        
        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        public async Task<List<GetPostDetailsVM>> GetPostDetails(int id)
        {
            var posts = await postRepository.GetFilteredList(
                selector: x => new GetPostDetailsVM
                {
                    ID = id,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,
                    AuthorFullName = x.AppUser.FullName,
                    AuthorImage = x.AppUser.ImagePath,
                    LikeCount = x.Likes.Count,
                    CommentCount = x.Comments.Count,
                    Comments = x.Comments.Where(x => x.PostId == id).OrderByDescending(x => x.CreationTime).Select(x => new GetCommentsVM
                    {
                        Id = x.Id,
                        Text = x.Text,
                        CreationTime = x.CreationTime,
                        UserImage = x.AppUser.ImagePath,
                        UserName = x.AppUser.UserName
                    }).ToList()
                },
                expression: x => x.Status != Status.Passive,
                orderBy: x => x.OrderByDescending(x => x.CreationTime),
                includes: x => x.Include(x => x.AppUser).ThenInclude(x => x.Comments));
                return posts;
        }

        public async Task<List<GetPostVM>> GetPosts()
        {
            var posts = await postRepository.GetFilteredList(
                 selector: x => new GetPostVM
                 {
                     Id = x.Id,
                     Title = x.Title,
                     Content = x.Content,
                     Image = x.Image,
                     AuthorFullName = x.AppUser.FullName,
                     AuthorImage = x.AppUser.ImagePath,
                     LikeCount = x.Likes.Count,
                     CommentCount = x.Comments.Count,
                 },
                 expression: x => x.Status != Status.Passive,
                 orderBy: x => x.OrderByDescending(x => x.CreationTime),
                 includes: x => x.Include(x => x.AppUser).ThenInclude(x => x.Comments));
            return posts;
        }
    }
}
