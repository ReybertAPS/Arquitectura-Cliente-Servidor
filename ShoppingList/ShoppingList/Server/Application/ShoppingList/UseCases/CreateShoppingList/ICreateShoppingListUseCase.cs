using ShoppingList.Domain;
using ShoppingList.Server.Application.Shared;
using System.Net;

namespace ShoppingList.Server.Application.ShoppingList.UseCases.CreateShoppingList
{
    public interface ICreateShoppingListUseCase
    {
        public ShoppingListHeader ShoppingListHeader { get; set; }

        public UseCaseResult Result { get; set; }

        public Task Execute(ShoppingListHeader shoppingListHeader);
    }
}