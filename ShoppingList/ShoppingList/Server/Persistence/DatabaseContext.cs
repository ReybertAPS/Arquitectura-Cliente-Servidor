using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain;

namespace ShoppingList.Server.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ShoppingListHeader> ShoppingListHeaders { get; set; }
        public virtual DbSet<ShoppingListDetail> ShoppingListDetails { get; set; }

        public async Task SaveBulkChangesAsync()
        {
            await this.BulkSaveChangesAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShoppingListHeader>(entity =>
            {
                entity.ToTable("ShoppingListHeader");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id");

                entity.Property(e => e.Description)
                    .HasColumnName("Description");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate");

                entity.Property(e => e.ShoppingTotalValue)
                    .HasColumnName("ShoppingTotalValue");
            });

            modelBuilder.Entity<ShoppingListDetail>(entity =>
            {
                entity.ToTable("ShoppingListDetail");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id");

                entity.Property(e => e.ShoppingListHeaderId)
                    .HasColumnName("ShoppingListHeaderId");

                entity.Property(e => e.ItemName)
                    .HasColumnName("ItemName");

                entity.Property(e => e.Quantity)
                    .HasColumnName("Quantity");

                entity.Property(e => e.UnitValue)
                    .HasColumnName("UnitValue");

                entity.Property(e => e.TotalValue)
                    .HasColumnName("TotalValue");
            });
        }
    }
}