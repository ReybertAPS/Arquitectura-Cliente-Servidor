namespace ShoppingList.Server.Persistence
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        Task BulkSaveChangesAsync();
        void Save();
    }
}
