namespace ShoppingList.Server.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _database;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _database = databaseContext;
        }

        public async Task BulkSaveChangesAsync()
        {
            await _database.SaveBulkChangesAsync();
        }

        public void Save()
        {
            _database.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _database.SaveChangesAsync();
        }
    }
}
