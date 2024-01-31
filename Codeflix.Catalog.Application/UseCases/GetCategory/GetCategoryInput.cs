using Codeflix.Catalog.Application.UseCases.Common;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases;

public class GetCategoryInput : IRequest<CategoryModelOutput>
{
    public Guid Id { get; set; }
    public GetCategoryInput(Guid id) 
        => Id = id;
}