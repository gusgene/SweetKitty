using MediatR;

using UseCases.Order.Dto;
namespace UseCases.Order.Queries.GetById
{
    public class GetOrderById : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
