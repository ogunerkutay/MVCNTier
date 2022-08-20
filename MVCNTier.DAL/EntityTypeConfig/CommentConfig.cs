using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCNTier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.DAL.EntityTypeConfig
{
    internal class CommentConfig:BaseEntityConfig<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.Property(x => x.Text).IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(x => x.Comments).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId);
            base.Configure(builder);
        }
    }
}
