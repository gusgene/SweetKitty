using System.Threading;
using System.Threading.Tasks;

using Entities.Models;

using Microsoft.EntityFrameworkCore;
namespace DataAccess.Interfaces
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; }
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
