using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Dal.Configurations
{
    internal class BirthInfoConfig : IEntityTypeConfiguration<BirthInfo>
    {
        public void Configure(EntityTypeBuilder<BirthInfo> builder)
        {
            //builder.HasNoKey();
        }
    }
}
