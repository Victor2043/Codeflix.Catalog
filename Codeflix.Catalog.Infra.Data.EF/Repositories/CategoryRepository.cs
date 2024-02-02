using Codeflix.Catalog.Application.Exceptions;
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
            => await _categories.AddAsync(aggregate, cancellationToken);
        

        public async Task<Category> Get(Guid id, CancellationToken cancellationToken)
        {
            var categories = new List<Category>();
            categories.Add(new Category("test", "descrição"));

            var category = await _categories.AsNoTracking().FirstOrDefaultAsync(
                  x => x.Id == id,
                  cancellationToken
              );
              NotFoundException.ThrowIfNull(category, $"Category '{id}' not found.");
              return category!;
        }

        public Task Update(Category aggregate, CancellationToken _)
            => Task.FromResult(_categories.Update(aggregate));

        public Task Delete(Category aggregate, CancellationToken _)
            => Task.FromResult(_categories.Remove(aggregate));

    }
}
