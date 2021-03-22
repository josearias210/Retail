using Retail.Application.Data;
using Retail.Application.UseCases.CreateOrder.Exceptions;
using Retail.Core.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.Application.UseCases.CreateOrder
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateOrderUseCase(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task ProcessAsync(CreateOrderMessage request)
        {
            var delivery = new Core.Domain.Entities.ValueObjects.Delivery(request.Delivery.StreetAddress, request.Delivery.City, request.Delivery.State, request.Delivery.ZipCode);
            var products = await this.unitOfWork.Product.GetProductByIdAsync(request.Products.Select(x => x.ProductId));

            var order = new Order(request.OrderId, DateTime.UtcNow, delivery);

            request.Products.ToList().ForEach(p =>
            {
                var product = products.FirstOrDefault(x => x.Id == p.ProductId);
                if (product == null)
                {
                    throw new ProductNotFoundApplicationException($"The product {p.ProductId} not found");
                }
                order.AddDetail(product.Id, product.Price, product.Description, p.Quantity);
            });

            if (order.Details.Count == 0)
            {
                throw new ProductIdOrderProductNeedsAtLeastOneDetailExeption($"The order needs at least one detail");
            }

            await this.unitOfWork.Order.CreateAsync(order);
            this.unitOfWork.Complete();
        }
    }
}