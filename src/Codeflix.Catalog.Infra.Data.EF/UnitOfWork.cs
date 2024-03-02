using Codeflix.Catalog.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Codeflix.Catalog.Infra.Data.EF;
public class UnitOfWork
    : IUnitOfWork
{
    private readonly CodeflixCatalogDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(
        CodeflixCatalogDbContext context,
        ILogger<UnitOfWork> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task Rollback(CancellationToken cancellationToken)
        => Task.CompletedTask;
}