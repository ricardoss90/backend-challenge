using CnabImporter.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CnabImporter.Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Owner).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cpf).HasMaxLength(11).IsRequired();
                entity.Property(e => e.Card).HasMaxLength(12).IsRequired();
                entity.Property(e => e.Value).HasPrecision(18, 2).IsRequired();

                entity.HasOne(t => t.Store)
                    .WithMany(s => s.Transactions)
                    .HasForeignKey(t => t.StoreId);
            });
        }
    }
}