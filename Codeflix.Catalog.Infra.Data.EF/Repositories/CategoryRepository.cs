using Codeflix.Catalog.Domain.Entities;
using Codeflix.Catalog.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Codeflix.Catalog.Infra.Data.EF.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CodeflixCatalogDbContext _context;
        private DbSet<Category> _categories => _context.Set<Category>();
        public CategoryRepository(CodeflixCatalogDbContext context)
        {
            _context = context;
        }
        public async Task Insert(Category aggregate, CancellationToken cancellationToken)
        {
            await _categories.AddAsync(aggregate, cancellationToken);
        }

        public Task Delete(Category aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Get(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        

        public Task Update(Category aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
