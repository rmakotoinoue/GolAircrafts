using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using GolAirCrafts.Domain.Entities;

namespace GolAirCrafts.Infra.Data.Mapping
{
    public class AirplaneMap : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.ToTable("Airplane");

            builder.HasKey(k => k.CodigoAviao);

            builder.Property(p => p.CodigoAviao)
                .IsRequired()
                .HasColumnName("CodigoAviao");
                

            builder.Property(p => p.ModeloAviao)
                .IsRequired()
                .HasColumnName("ModelAviao");

            builder.Property(p => p.QuantidadePassageiros)
                .IsRequired()
                .HasColumnName("QuantidadePassageiros");

            builder.Property(p => p.DataCriacao)
                .IsRequired()
                .HasColumnName("DataCriacao");

        }
    }
}
