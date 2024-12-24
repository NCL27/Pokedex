using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Pokemons> Pokemons { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Types> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            #region tables
            modelBuilder.Entity<Pokemons>().ToTable("Pokemons");
            modelBuilder.Entity<Regions>().ToTable("Regions");
            modelBuilder.Entity<Types>().ToTable("Types");
            #endregion

            #region Primary keys
            modelBuilder.Entity<Pokemons>().HasKey(pokemons => pokemons.Id);
            modelBuilder.Entity<Regions>().HasKey(regions => regions.Id);
            modelBuilder.Entity<Types>().HasKey(Types => Types.Id);
            #endregion

            #region Relationships
            modelBuilder.Entity<Regions>()
                .HasMany<Pokemons>(regions => regions.Pokemons)
                .WithOne(pokemons => pokemons.Regions)
                .HasForeignKey(pokemons => pokemons.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Types>()
             .HasMany<Pokemons>(types => types.Pokemons)
             .WithOne(pokemons => pokemons.Types)
             .HasForeignKey(pokemons => pokemons.TypeId)
             .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Property configurations
            #region Regions
            modelBuilder.Entity<Regions>()
                .Property(regions => regions.Name)
                .IsRequired();
            #endregion
            #region types
            modelBuilder.Entity<Types>()
                .Property(types => types.Name)
                .IsRequired();
            #endregion
            #region Pokemons
            modelBuilder.Entity<Pokemons>()
                .Property(pokemons => pokemons.Name)
                .IsRequired();
            modelBuilder.Entity<Pokemons>()
                .Property(pokemons => pokemons.Name)
                .IsRequired();
            #endregion
            #endregion

        }
    }
}
