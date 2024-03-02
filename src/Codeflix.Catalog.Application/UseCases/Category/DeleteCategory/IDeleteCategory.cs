using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Category.DeleteCategory;
public interface IDeleteCategory

{ 
    Task<Unit> Handle(DeleteCategoryInput request, CancellationToken cancellationToken);  
}