using ShoppingList.Domain;
using ShoppingList.Server.Application.Shared;
using ShoppingList.Server.Persistence;
using System.Net;

namespace ShoppingList.Server.Application.ShoppingList.UseCases.ModifyShoppingList
{
    public class ModifyShoppingListUseCase : IModifyShoppingListUseCase
    {
        private readonly IRepository<ShoppingListHeader, int> _shoppingListHeaderRepository;
        private readonly IRepository<ShoppingListDetail, int> _shoppingListDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ModifyShoppingListUseCase(IRepository<ShoppingListHeader, int> shoppingListHeaderRepository, IRepository<ShoppingListDetail, int> shoppingListDetailRepository, IUnitOfWork unitOfWork)
        {
            _shoppingListHeaderRepository = shoppingListHeaderRepository;
            _shoppingListDetailRepository = shoppingListDetailRepository;

            _unitOfWork = unitOfWork;
        }

        public ShoppingListHeader ShoppingListHeader { get; set; }
        public UseCaseResult Result { get; set; } = new UseCaseResult();

        public async Task Execute(ShoppingListHeader shoppingListHeader)
        {
            var dbShoppingListHeader = await _shoppingListHeaderRepository.GetAsync(shoppingListHeader.Id);

            if (dbShoppingListHeader == null)
            {
                this.Result.StatusCode = HttpStatusCode.BadRequest;

                this.Result.Message = $"No se encontró la Lista de compras con el Id {shoppingListHeader.Id}";

                return;
            }

            var dbShoppingListDetails = _shoppingListDetailRepository.GetAll().Where(d => d.ShoppingListHeaderId == shoppingListHeader.Id).ToList();

            List<ShoppingListDetail> newShoppingListDetails = new List<ShoppingListDetail>();

            shoppingListHeader.ShoppingListDetails.ToList().ForEach(detail =>
            {
                var shoppingListDetail = dbShoppingListDetails.Where(d => d.Id == detail.Id && d.ShoppingListHeaderId == detail.ShoppingListHeaderId);

                if (shoppingListDetail.Any())
                    detail = shoppingListDetail.FirstOrDefault();
                else
                    newShoppingListDetails.Add(detail);
            });

            List<ShoppingListDetail> removeShoppingListDetails = new List<ShoppingListDetail>();

            dbShoppingListDetails.ToList().ForEach(detail =>
            {
                var shoppingListDetail = shoppingListHeader.ShoppingListDetails.Where(d => d.Id == detail.Id && d.ShoppingListHeaderId == detail.ShoppingListHeaderId);

                if (!shoppingListDetail.Any())
                {
                    _shoppingListDetailRepository.Remove(detail);
                }
            });

            newShoppingListDetails.ForEach(detail =>
            {
                detail.ShoppingListHeaderId = shoppingListHeader.Id;

                _shoppingListDetailRepository.Add(detail);
            });

            await _unitOfWork.SaveAsync();

            this.Result.StatusCode = HttpStatusCode.OK;
        }
    }
}