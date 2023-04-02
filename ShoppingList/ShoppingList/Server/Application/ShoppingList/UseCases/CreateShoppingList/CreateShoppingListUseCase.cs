using ShoppingList.Domain;
using ShoppingList.Server.Application.Shared;
using ShoppingList.Server.Persistence;
using System.Net;

namespace ShoppingList.Server.Application.ShoppingList.UseCases.CreateShoppingList
{
    public class CreateShoppingListUseCase : ICreateShoppingListUseCase
    {
        private readonly IRepository<ShoppingListHeader, int> _shoppingListHeaderRepository;
        private readonly IRepository<ShoppingListDetail, int> _shoppingListDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateShoppingListUseCase(IRepository<ShoppingListHeader, int> shoppingListHeaderRepository, IRepository<ShoppingListDetail, int> shoppingListDetailRepository, IUnitOfWork unitOfWork)
        {
            _shoppingListHeaderRepository = shoppingListHeaderRepository;
            _shoppingListDetailRepository = shoppingListDetailRepository;

            _unitOfWork = unitOfWork;
        }

        public ShoppingListHeader ShoppingListHeader { get; set; }

        public UseCaseResult Result { get; set; } = new UseCaseResult();

        public async Task Execute(ShoppingListHeader shoppingListHeader)
        {
            shoppingListHeader.CreatedDate = DateTime.Now;

            var existShoppingListHeader = _shoppingListHeaderRepository.GetAll().Where(l => l.Description == shoppingListHeader.Description).FirstOrDefault();

            if (existShoppingListHeader != null)
            {
                this.Result.StatusCode = HttpStatusCode.BadRequest;

                this.Result.Message = "Ya existe una lista de compras con la misma descripción";

                return;
            }

            _shoppingListHeaderRepository.Add(shoppingListHeader);

            if (shoppingListHeader.ShoppingListDetails == null || !shoppingListHeader.ShoppingListDetails.Any())
            {
                this.Result.StatusCode = HttpStatusCode.BadRequest;

                this.Result.Message = "La lista de compras no tiene un detalle";

                return;
            }

            _unitOfWork.Save();

            shoppingListHeader.ShoppingListDetails.ToList().ForEach(d =>
            {
                d.ShoppingListHeaderId = shoppingListHeader.Id;
            });

            this.ShoppingListHeader = shoppingListHeader;
            this.Result = new UseCaseResult { StatusCode = HttpStatusCode.OK};
        }
    }
}