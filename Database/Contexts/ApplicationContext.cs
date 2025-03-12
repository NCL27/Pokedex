
using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Domain.Common;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Pokemons> Pokemons { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Types> Types { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }
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
