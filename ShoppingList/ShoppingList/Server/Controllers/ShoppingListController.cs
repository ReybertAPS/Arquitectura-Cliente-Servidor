using Microsoft.AspNetCore.Mvc;
using ShoppingList.Domain;
using ShoppingList.Server.Application.ShoppingList.UseCases.CreateShoppingList;
using ShoppingList.Server.Application.ShoppingList.UseCases.DeleteShoppingList;
using ShoppingList.Server.Application.ShoppingList.UseCases.GetAllShoppingList;
using ShoppingList.Server.Application.ShoppingList.UseCases.GetShoppingList;
using ShoppingList.Server.Application.ShoppingList.UseCases.ModifyShoppingList;
using System.Net;

namespace ShoppingList.Server.Controllers
{
    [Route("api/v1.0.0/shopping-list")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IGetAllShoppingListUseCase _getAllShoppingListUseCase;
        private readonly IGetShoppingListUseCase _getShoppingListUseCase;
        private readonly ICreateShoppingListUseCase _createShoppingListUseCase;
        private readonly IDeleteShoppingListUseCase _deleteShoppingListUseCase;
        private readonly IModifyShoppingListUseCase _modifyShoppingListUseCase;

        public ShoppingListController(IGetAllShoppingListUseCase getAllShoppingListUseCase, ICreateShoppingListUseCase createShoppingListUseCase, IDeleteShoppingListUseCase deleteShoppingListUseCase, IGetShoppingListUseCase getShoppingListUseCase, IModifyShoppingListUseCase modifyShoppingListUseCase)
        {
            _getAllShoppingListUseCase = getAllShoppingListUseCase;
            _getShoppingListUseCase = getShoppingListUseCase;
            _createShoppingListUseCase = createShoppingListUseCase;
            _deleteShoppingListUseCase = deleteShoppingListUseCase;
            _modifyShoppingListUseCase = modifyShoppingListUseCase;
        }

        [HttpGet("get-all-shopping-list")]
        public async Task<List<ShoppingListHeader>> GetAllShoppingList()
        {
            await _getAllShoppingListUseCase.Execute();

            return _getAllShoppingListUseCase.ShoppingListHeaders;
        }

        [HttpGet("get-shopping-list/{id}")]
        public async Task<ShoppingListHeader> GetShoppingList(int id)
        {
            await _getShoppingListUseCase.Execute(id);

            return _getShoppingListUseCase.ShoppingListHeader;
        }

        [HttpPost("create-shopping-list")]
        public async Task<IActionResult> CreateShoppingList(ShoppingListHeader shoppingListHeader)
        {
            await _createShoppingListUseCase.Execute(shoppingListHeader);

            if (_createShoppingListUseCase.Result.StatusCode == HttpStatusCode.OK)
                return Ok(_createShoppingListUseCase.ShoppingListHeader);
            else
                return BadRequest(_createShoppingListUseCase.Result.Message);
        }

        [HttpDelete("delete-shopping-list/{id}")]
        public async Task<IActionResult> CreateShoppingList(int id)
        {
            await _deleteShoppingListUseCase.Execute(id);

            if (_deleteShoppingListUseCase.Result.StatusCode == HttpStatusCode.OK)
                return Ok();
            else
                return BadRequest(_deleteShoppingListUseCase.Result.Message);
        }

        [HttpPost("modify-shopping-list")]
        public async Task<IActionResult> ModifyShoppingList(ShoppingListHeader shoppingListHeader)
        {
            await _modifyShoppingListUseCase.Execute(shoppingListHeader);

            if (_modifyShoppingListUseCase.Result.StatusCode == HttpStatusCode.OK)
                return Ok(_modifyShoppingListUseCase.ShoppingListHeader);
            else
                return BadRequest(_modifyShoppingListUseCase.Result.Message);
        }
    }
}
