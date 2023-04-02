using ShoppingList.Domain;
using ShoppingList.Server.Persistence;

namespace ShoppingList.Server.Application.ShoppingList.UseCases.GetShoppingList
{
    public class GetShoppingListUseCase : IGetShoppingListUseCase
    {
        private readonly IRepository<ShoppingListHeader, int> _shoppingListHeaderRepository;
        private readonly IRepository<ShoppingListDetail, int> _shoppingListDetailRepository;

        public GetShoppingListUseCase(IRepository<ShoppingListHeader, int> shoppingListHeaderRepository, IRepository<ShoppingListDetail, int> shoppingListDetailRepository)
        {
            _shoppingListHeaderRepository = shoppingListHeaderRepository;
            _shoppingListDetailRepository = shoppingListDetailRepository;
        }

        public ShoppingListHeader ShoppingListHeader { get; set; }

        public async Task Execute(int id)
        {
            ShoppingListHeader = await _shoppingListHeaderRepository.GetAsync(id);

            _shoppingListDetailRepository.GetAll().Where(d => d.ShoppingListHeaderId == id).ToList();
        }
    }
}