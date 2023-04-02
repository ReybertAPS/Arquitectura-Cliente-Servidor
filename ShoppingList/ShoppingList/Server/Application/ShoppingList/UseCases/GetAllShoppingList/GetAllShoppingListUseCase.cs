using ShoppingList.Domain;
using ShoppingList.Server.Persistence;

namespace ShoppingList.Server.Application.ShoppingList.UseCases.GetAllShoppingList
{
    public class GetAllShoppingListUseCase : IGetAllShoppingListUseCase
    {
        private readonly IRepository<ShoppingListHeader, int> _shoppingListHeaderRepository;
        private readonly IRepository<ShoppingListDetail, int> _shoppingListDetailRepository;

        public GetAllShoppingListUseCase(IRepository<ShoppingListHeader, int> shoppingListHeaderRepository, IRepository<ShoppingListDetail, int> shoppingListDetailRepository)
        {
            _shoppingListHeaderRepository = shoppingListHeaderRepository;
            _shoppingListDetailRepository = shoppingListDetailRepository;
        }

        public List<ShoppingListHeader> ShoppingListHeaders { get; set; }

        public async Task Execute()
        {
            ShoppingListHeaders = _shoppingListHeaderRepository.GetAll().ToList();

            _shoppingListDetailRepository.GetAll().ToList();
        }
    }
}