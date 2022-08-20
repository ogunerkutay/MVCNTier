using MVCNTier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.DAL.EntityTypeConfig
{
    internal class PostConfig:BaseEntityConfig<Post>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(x => x.Posts).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Genre).WithMany(x => x.Posts).HasForeignKey(x => x.GenreId);
            base.Configure(builder);
        }
    }
}
