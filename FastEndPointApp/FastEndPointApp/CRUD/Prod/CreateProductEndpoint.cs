using FastEndPointApp.DAL;
using FastEndPointApp.Model;
using FastEndpoints;

namespace FastEndPointApp.CRUD.Prod
{
    public class CreateProductEndpoint : Endpoint<Product>
    {
        public override void Configure()
        {
            Post("/products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Product req, CancellationToken ct)
        {
            req.Id = InMemoryDatabase.Products.Count + 1;
            InMemoryDatabase.Products.Add(req);
            await SendOkAsync(req, ct);
        }
    }
}
