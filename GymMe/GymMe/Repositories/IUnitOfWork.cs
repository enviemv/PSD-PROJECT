using System;
using System.Threading.Tasks;
using GymMe.Models;

namespace GymMe.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<TransactionHeader> TransactionHeaders { get; }
        IRepository<TransactionDetail> TransactionDetails { get; }
        IRepository<Cart> Carts { get; }
        IRepository<Supplement> Supplements { get; }
        IRepository<SupplementType> SupplementTypes { get; }

        Task<int> CompleteAsync();
    }
}
