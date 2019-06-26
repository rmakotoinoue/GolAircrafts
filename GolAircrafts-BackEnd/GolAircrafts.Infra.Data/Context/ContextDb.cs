using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using GolAirCrafts.Domain.Entities;
using GolAirCrafts.Infra.Data.Mapping;

namespace GolAirCrafts.Infra.Data.Context
{
    public class ContextDb : DbContext
    {

        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }

        public DbSet<Airplane> Airplanes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airplane>(new AirplaneMap().Configure);
        }
    }


}
