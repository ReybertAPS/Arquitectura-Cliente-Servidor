using ShoppingList.Server.Application.Shared;

namespace ShoppingList.Server.Application.ShoppingList.UseCases.DeleteShoppingList
{
    public interface IDeleteShoppingListUseCase
    {
        public UseCaseResult Result { get; set; }

        public Task Execute(int id);
    }
}