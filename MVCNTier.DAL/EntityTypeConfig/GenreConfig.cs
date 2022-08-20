using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCNTier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.DAL.EntityTypeConfig
{
    internal class GenreConfig:BaseEntityConfig<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            base.Configure(builder);
        }
    }
}
