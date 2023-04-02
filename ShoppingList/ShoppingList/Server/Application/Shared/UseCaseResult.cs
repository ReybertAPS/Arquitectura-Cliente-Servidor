using System.Net;

namespace ShoppingList.Server.Application.Shared
{
    public class UseCaseResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
