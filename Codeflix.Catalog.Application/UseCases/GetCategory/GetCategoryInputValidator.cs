namespace Codeflix.Catalog.Application.UseCases;

public class GetCategoryInputValidator 
    : AbstractValidator<GetCategoryInput>
{
    public GetCategoryInputValidator()
        => RuleFor(x => x.Id).NotEmpty();
}