using ShoppingList.Server.Application.ShoppingList.UseCases.CreateShoppingList;
using ShoppingList.Server.Application.ShoppingList.UseCases.DeleteShoppingList;
using ShoppingList.Server.Application.ShoppingList.UseCases.GetAllShoppingList;
using ShoppingList.Server.Application.ShoppingList.UseCases.GetShoppingList;
using ShoppingList.Server.Application.ShoppingList.UseCases.ModifyShoppingList;

namespace ShoppingList.Server.Shared.Initialize
{
    public static class ApplicationDependenciesManager
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //ShoppingList
            services.AddTransient(typeof(IGetAllShoppingListUseCase), typeof(GetAllShoppingListUseCase));
            services.AddTransient(typeof(IGetShoppingListUseCase), typeof(GetShoppingListUseCase));
            services.AddTransient(typeof(ICreateShoppingListUseCase), typeof(CreateShoppingListUseCase));
            services.AddTransient(typeof(IDeleteShoppingListUseCase), typeof(DeleteShoppingListUseCase));
            services.AddTransient(typeof(IModifyShoppingListUseCase), typeof(ModifyShoppingListUseCase));
        }
    }
}