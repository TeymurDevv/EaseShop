using EaseShop.Domain.Repositories;
using EaseShop.Persistance.Data;

namespace EaseShop.Persistance.Implementations;

 public class UnitOfWork : IUnitOfWork
 {

        private readonly EaseDbContext _applicationDbContext;
        private bool _disposed;

        public ICategoryRepository CategoryRepository { get; private set; }
        public ISubCategoryRepository SubCategoryRepository { get; private set; }

        public UnitOfWork(EaseDbContext applicationDbContext)
        {
            CategoryRepository = new CategoryRepository(applicationDbContext);
            SubCategoryRepository = new SubCategoryRepository(applicationDbContext);

            _applicationDbContext = applicationDbContext;

        }
        
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            var transaction = _applicationDbContext.Database.CurrentTransaction;
            if (transaction == null)
            {
                await _applicationDbContext.Database.BeginTransactionAsync(cancellationToken);
            }
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            var transaction = _applicationDbContext.Database.CurrentTransaction;
            if (transaction != null)
            {
                await transaction.CommitAsync();
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            var transaction = _applicationDbContext.Database.CurrentTransaction;
            if (transaction != null)
            {
                await transaction.RollbackAsync();
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
            }

            _disposed = true;
        }
}