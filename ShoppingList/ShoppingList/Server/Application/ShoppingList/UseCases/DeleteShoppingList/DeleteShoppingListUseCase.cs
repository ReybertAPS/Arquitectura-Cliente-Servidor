using ShoppingList.Domain;
using ShoppingList.Server.Application.Shared;
using ShoppingList.Server.Persistence;
using System.Net;

namespace ShoppingList.Server.Application.ShoppingList.UseCases.DeleteShoppingList
{
    public class DeleteShoppingListUseCase : IDeleteShoppingListUseCase
    {
        private readonly IRepository<ShoppingListHeader, int> _shoppingListHeaderRepository;
        private readonly IRepository<ShoppingListDetail, int> _shoppingListDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteShoppingListUseCase(IRepository<ShoppingListHeader, int> shoppingListHeaderRepository, IRepository<ShoppingListDetail, int> shoppingListDetailRepository, IUnitOfWork unitOfWork)
        {
            _shoppingListHeaderRepository = shoppingListHeaderRepository;
            _shoppingListDetailRepository = shoppingListDetailRepository;

            _unitOfWork = unitOfWork;
        }

        public UseCaseResult Result { get; set; } = new UseCaseResult();

        public async Task Execute(int id)
        {
            var shoppingListHeader = await _shoppingListHeaderRepository.GetAsync(id);

            var shoppingListDetails = _shoppingListDetailRepository.GetAll().Where(d => d.ShoppingListHeaderId == id);

            if (shoppingListHeader == null)
            {
                Result.StatusCode = HttpStatusCode.BadRequest;

                Result.Message = "No se encontró la lista de compras que desa eliminar";

                return;
            }

            foreach (var shoppinfgListDetail in shoppingListDetails)
            {
                _shoppingListDetailRepository.Remove(shoppinfgListDetail);
            }

            await _unitOfWork.SaveAsync();

            _shoppingListHeaderRepository.Remove(shoppingListHeader);

            await _unitOfWork.SaveAsync();

            Result.StatusCode = HttpStatusCode.OK;
        }
    }
}