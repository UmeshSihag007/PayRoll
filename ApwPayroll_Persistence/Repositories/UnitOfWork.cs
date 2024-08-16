using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common;
using ApwPayroll_Persistence.Data;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace ApwPayroll_Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDataContext _dbContext;
    private Hashtable _repositories;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private bool disposed;

    public UnitOfWork(ApplicationDataContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public IGenericRepository<T> Repository<T>() where T : BaseAuditEntity
    {
        if (_repositories == null)
            _repositories = new Hashtable();
        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);

            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext, _httpContextAccessor);

            _repositories.Add(type, repositoryInstance);
        }

        return (IGenericRepository<T>)_repositories[type];
    }

    public Task Rollback()
    {
        _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        return Task.CompletedTask;
    }

    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
    public Task<int> SaveAndRemoveCache(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        Dispose(true);
            GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            if (disposing)
            {
                //dispose managed resources
                _dbContext.Dispose();
            }
        }
        //dispose unmanaged resources
        disposed = true;
    }




}