using FastEndPointApp.DAL;
using FastEndpoints;

namespace FastEndPointApp.CRUD.Prod
{
    public class GetProductsEndpoint : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("/products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendOkAsync(InMemoryDatabase.Products, ct);
        }
    }
}
