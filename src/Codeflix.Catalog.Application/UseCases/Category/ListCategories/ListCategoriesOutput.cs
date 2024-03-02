using Codeflix.Catalog.Application.UseCases.Category.Common;
using Codeflix.Catalog.Application.Common;


namespace Codeflix.Catalog.Application.UseCases.Category.ListCategories;
public class ListCategoriesOutput
    : PaginatedListOutput<CategoryModelOutput>
{
    public ListCategoriesOutput(
        int page,
        int perPage,
        int total,
        IReadOnlyList<CategoryModelOutput> items)
        : base(page, perPage, total, items)
    {
    }
}