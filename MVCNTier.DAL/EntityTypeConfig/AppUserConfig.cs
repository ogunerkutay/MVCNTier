using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCNTier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.DAL.EntityTypeConfig
{
    internal class AppUserConfig:BaseEntityConfig<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired();
            base.Configure(builder);
        }
    }
}
