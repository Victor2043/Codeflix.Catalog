using Codeflix.Catalog.Application.UseCases.Common;

namespace Codeflix.Catalog.Application.UseCases;

public class GetCategory : IGetCategory
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategory(ICategoryRepository categoryRepository) 
        => _categoryRepository = categoryRepository;

    public async Task<CategoryModelOutput> Handle(
        GetCategoryInput request, 
        CancellationToken cancellationToken
    )
    {
        var category = await _categoryRepository.Get(request.Id, cancellationToken);
        return CategoryModelOutput.FromCategory(category);
    }
}