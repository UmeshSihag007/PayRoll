using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Application.Interfaces.Repositories.Documents;
using ApwPayroll_Application.Interfaces.Repositories.EmployeeDocuments;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Persistence.Data;
using ApwPayroll_Persistence.Repositories;
using ApwPayroll_Persistence.Repositories.EmployeeDocuments;
using Certificate_Persistence.Repositories.Documents;
using Couchbase.Management.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApwPayroll_Persistence.Extensions
{
    public static class PersistenceServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext(configuration);
            services.AddRepositories();

        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDataContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDataContext).Assembly.FullName)));

            services.AddIdentity<AspUser, IdentityRole>()
         .AddEntityFrameworkStores<ApplicationDataContext>()
         .AddDefaultTokenProviders()
     .AddSignInManager<SignInManager<AspUser>>();



        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                       .AddTransient<IDocumentRepository, DocumentRepository>()
                      .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                      .AddTransient<INotificationRepository, NotificationRepository>()
                      .AddTransient<IEmployeeDocumentRepository, EmployeeDocumentRepository>()
                /*.AddTransient<IDocumentRepository, DocumentRepository>()*/
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }

    }
}
