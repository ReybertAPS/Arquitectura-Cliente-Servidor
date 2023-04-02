using ShoppingList.Server.Persistence;

namespace ShoppingList.Server.Shared.Initialize
{
    public static class PersistenceDependenciesManager
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IDatabaseContext), typeof(DatabaseContext), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUnitOfWork), typeof(UnitOfWork), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepository<,>), typeof(Repository<,>), ServiceLifetime.Transient));
        }
    }
}
