using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCNTier.Core.Entities;
using MVCNTier.DAL.EntityTypeConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        DbSet<AppUser> AppUsers { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new GenreConfig());
            builder.ApplyConfiguration(new LikeConfig());
            builder.ApplyConfiguration(new PostConfig());
            base.OnModelCreating(builder);
        }



    }
}
