using FastEndPointApp.DAL;
using FastEndPointApp.Model;
using FastEndpoints;

namespace FastEndPointApp.CRUD.Prod
{
    public class DeleteProductEndpoint : Endpoint<ProductRequest>
    {
        public override void Configure()
        {
            Delete("/products/{id:int}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(ProductRequest req, CancellationToken ct)
        {
            var product = InMemoryDatabase.Products.FirstOrDefault(p => p.Id == req.Id);
            if (product is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            InMemoryDatabase.Products.Remove(product);
            await SendOkAsync(product, ct);
        }
    }
}
