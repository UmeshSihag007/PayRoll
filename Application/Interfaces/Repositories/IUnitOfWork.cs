using ApwPayroll_Domain.common;

namespace ApwPayroll_Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseAuditEntity;
        Task<int> Save(CancellationToken cancellationToken);
        Task Rollback();
    }
}
