using ApwPayroll_Application.Common.Exceptions;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common;
using ApwPayroll_Persistence.Data;
using ApwPayroll_Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ApwPayroll_Persistence.Repositories
{
    public class GenericRepository<T> : IRequest<Result<List<T>>>, IGenericRepository<T> where T : BaseAuditEntity
    {
        private readonly ApplicationDataContext _applicationDataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GenericRepository(ApplicationDataContext applicationDataContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDataContext = applicationDataContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public IQueryable<T> Entities => _applicationDataContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            var userid = _httpContextAccessor.HttpContext.User.FindFirst("id")?.Value;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = !string.IsNullOrEmpty(userid) ? userid : null;
            await _applicationDataContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is BaseAuditEntity auditableEntity)
            {
                var userid = _httpContextAccessor.HttpContext.User.FindFirst("id")?.Value;
                auditableEntity.IsDeleted = true;
                auditableEntity.DeletedAt = DateTime.Now;
                auditableEntity.UpdatedOn = DateTime.Now;
                auditableEntity.UpdatedBy = !string.IsNullOrEmpty(userid) ? userid : null;
                _applicationDataContext.Entry(auditableEntity).State = EntityState.Modified;
                await _applicationDataContext.SaveChangesAsync();
            }
            return;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var data = await _applicationDataContext
              .Set<T>()
                 .Where(e => !e.IsDeleted)
              .ToListAsync();
 

            return data;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _applicationDataContext
              .Set<T>()
                 .Where(e => !e.IsDeleted && e.Id == id)
                 .FirstOrDefaultAsync();
      
            return data;
        }

        public Task UpdateAsync(T entity)
        {
            var userid = _httpContextAccessor.HttpContext.User.FindFirst("id")?.Value;
            T exist = _applicationDataContext.Set<T>().Find(entity.Id);
            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = !string.IsNullOrEmpty(userid) ? userid : null;
            _applicationDataContext.Entry(exist).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }
    }
}
