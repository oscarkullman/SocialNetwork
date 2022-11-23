using WebAPI.Data;

namespace WebAPI.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            _context.SaveChanges();
        }
    }
}
