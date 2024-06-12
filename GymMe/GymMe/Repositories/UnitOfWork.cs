using System.Threading.Tasks;
using GymMe.Models;
using GymMe.Data;

namespace GymMe.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new Repository<User>(_context);
            TransactionHeaders = new Repository<TransactionHeader>(_context);
            TransactionDetails = new Repository<TransactionDetail>(_context);
            Carts = new Repository<Cart>(_context);
            Supplements = new Repository<Supplement>(_context);
            SupplementTypes = new Repository<SupplementType>(_context);
        }

        public IRepository<User> Users { get; private set; }
        public IRepository<TransactionHeader> TransactionHeaders { get; private set; }
        public IRepository<TransactionDetail> TransactionDetails { get; private set; }
        public IRepository<Cart> Carts { get; private set; }
        public IRepository<Supplement> Supplements { get; private set; }
        public IRepository<SupplementType> SupplementTypes { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
