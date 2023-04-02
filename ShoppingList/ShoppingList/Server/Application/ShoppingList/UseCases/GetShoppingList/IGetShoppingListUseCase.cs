using ShoppingList.Domain;

namespace ShoppingList.Server.Application.ShoppingList.UseCases.GetShoppingList
{
    public interface IGetShoppingListUseCase
    {
        public ShoppingListHeader ShoppingListHeader { get; set; }

        public Task Execute(int id);
    }
}