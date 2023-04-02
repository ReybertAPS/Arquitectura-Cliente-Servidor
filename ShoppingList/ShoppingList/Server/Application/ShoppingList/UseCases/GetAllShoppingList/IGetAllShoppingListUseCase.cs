using ShoppingList.Domain;

namespace ShoppingList.Server.Application.ShoppingList.UseCases.GetAllShoppingList
{
    public interface IGetAllShoppingListUseCase
    {
        public List<ShoppingListHeader> ShoppingListHeaders { get; set; }

        public Task Execute();
    }
}