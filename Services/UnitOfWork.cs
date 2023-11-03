using Reporter.Data;
using Reporter.Entities.Base;

namespace Reporter.Services;

public interface IUnitOfWork
{
    ReporterDbContext Db { get; }

    IQueryable<T> Query<T>() where T : class, IEntity;

    Task<bool> CommitAsync();
}

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ReporterDbContext reporterDbContext)
    {
        Db = reporterDbContext;
    }

    public ReporterDbContext Db { get; }

    public IQueryable<T> Query<T>() where T : class, IEntity
    {
        return Db.Set<T>().AsQueryable();
    }

    public async Task<bool> CommitAsync()
    {
        return await Db.SaveChangesAsync() > 0;
    }
}