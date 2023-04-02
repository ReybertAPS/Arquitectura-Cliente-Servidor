using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain;

namespace ShoppingList.Server.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<ShoppingListHeader> ShoppingListHeaders { get; set; }
        DbSet<ShoppingListDetail> ShoppingListDetails { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task SaveBulkChangesAsync();
        DbSet<T> Set<T>() where T : class;
    }
}
