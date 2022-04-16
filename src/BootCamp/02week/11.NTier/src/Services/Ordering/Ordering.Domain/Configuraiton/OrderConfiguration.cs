using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Configuraiton
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(p => p.UserName).IsRequired();

            #region ForeingKey



            #endregion

            #region Index

            //entity.HasIndex(e => new { e.u }, "UIX_Name").IsUnique();

            #endregion
        }
    }
}
