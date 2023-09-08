using Dastone.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dastone.Data.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            #region Padrão
            builder.HasKey(u => u.Id);
            builder.Property(u => u.RegisterDate).IsRequired().HasComment("Grava a data da criação do registro");
            builder.Property(u => u.ChangeDate).HasComment("Grava a data da modifição do registro");
            builder.Property(u => u.Observation).HasMaxLength(2000);

            //Enum
            builder.Property(u => u.Situations).IsRequired().HasDefaultValueSql("0");
            #endregion

            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Address).IsRequired().HasMaxLength(80);
            builder.Property(u => u.AddressNumber).IsRequired().HasMaxLength(10);
            builder.Property(u => u.ZipCode).IsRequired().HasMaxLength(8);
            builder.Property(u => u.neighborhood).IsRequired().HasMaxLength(80);
        }
    }
}
