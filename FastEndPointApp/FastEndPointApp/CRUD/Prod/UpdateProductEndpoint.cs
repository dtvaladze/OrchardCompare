using FastEndPointApp.DAL;
using FastEndPointApp.Model;
using FastEndpoints;

namespace FastEndPointApp.CRUD.Prod
{
    public class UpdateProductEndpoint : Endpoint<Product>
    {
        public override void Configure()
        {
            Put("/products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Product req, CancellationToken ct)
        {
            var product = InMemoryDatabase.Products.FirstOrDefault(p => p.Id == req.Id);
            if (product is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            product.Name = req.Name;
            product.Price = req.Price;
            product.TenantId = req.TenantId;

            await SendOkAsync(product, ct);
        }
    }
}
