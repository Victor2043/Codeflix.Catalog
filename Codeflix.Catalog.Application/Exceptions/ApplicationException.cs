
namespace Codeflix.Catalog.Domain.Exceptions
{
    public class ApplicationException : Exception
    {
        protected ApplicationException(string? message) : base(message)
        { }
    }
}
