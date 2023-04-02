using ShoppingList.Domain;
using ShoppingList.Server.Application.Shared;

namespace ShoppingList.Server.Application.ShoppingList.UseCases.ModifyShoppingList
{
    public interface IModifyShoppingListUseCase
    {
        public ShoppingListHeader ShoppingListHeader { get; set; }

        public UseCaseResult Result { get; set; }

        public Task Execute(ShoppingListHeader shoppingListHeader);
    }
}