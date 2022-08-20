﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCNTier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.DAL.EntityTypeConfig
{
    internal class LikeConfig:BaseEntityConfig<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasOne(x => x.AppUser).WithMany(x => x.Likes).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Post).WithMany(x => x.Likes).HasForeignKey(x => x.PostId);
            base.Configure(builder);
        }
    }
}
