using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using DataAccess.Interfaces;

using MediatR;
namespace UseCases.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public CreateOrderCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Entities.Models.Order>(request.Dto);
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}
