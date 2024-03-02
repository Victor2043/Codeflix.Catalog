using Codeflix.Catalog.Domain.Entities;
using Codeflix.Catalog.Domain.SeedWork.SearchableRepository;
using Codeflix.Catalog.Domain.SeedWork;


namespace Codeflix.Catalog.Domain.Repository;
public interface ICategoryRepository
    : IGenericRepository<Category>,
    ISearchableRepository<Category>
{
    public Task<IReadOnlyList<Guid>> GetIdsListByIds(
        List<Guid> ids,
        CancellationToken cancellationToken
    );

    public Task<IReadOnlyList<Category>> GetListByIds(
        List<Guid> ids,
        CancellationToken cancellationToken
    );
}