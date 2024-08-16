using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Application.Interfaces.Repositories.Documents;
using ApwPayroll_Application.Interfaces.Repositories.EmployeeDocuments;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Persistence.Data;
using ApwPayroll_Persistence.Repositories;
using ApwPayroll_Persistence.Repositories.EmployeeDocuments;
using Certificate_Persistence.Repositories.Documents;
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

            services.AddIdentity<AspUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.User.RequireUniqueEmail = false;
            })
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
