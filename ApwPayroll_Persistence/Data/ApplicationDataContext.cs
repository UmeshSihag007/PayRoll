using ApwPayroll_Domain.Entities;
using ApwPayroll_Domain.Entities.AddressTypes;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Domain.Entities.Banks.BankDetails;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Banks.Branches.BranchAddresses;
using ApwPayroll_Domain.Entities.Banks.Branches.BranchContacts;
using ApwPayroll_Domain.Entities.Banks.Branches.BranchDocuments;
using ApwPayroll_Domain.Entities.Banks.Branches.BranchDocuments.BranchDocumentTypes;
using ApwPayroll_Domain.Entities.Banks.Branches.BranchNumberFormats;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Domain.Entities.Documents;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.Checklists;
using ApwPayroll_Domain.Entities.Employees.ContactTypes;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Domain.Entities.Employees.EmergencyContacts;
using ApwPayroll_Domain.Entities.Employees.EmployeeAddresses;
using ApwPayroll_Domain.Entities.Employees.EmployeeChecklists;
using ApwPayroll_Domain.Entities.Employees.EmployeeContacts;
using ApwPayroll_Domain.Entities.Employees.EmployeeDepartments;
using ApwPayroll_Domain.Entities.Employees.EmployeeDesignations;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Domain.Entities.Employees.EmployeeLanguages;
using ApwPayroll_Domain.Entities.Employees.EmployeeLicenses;
using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Domain.Entities.Employees.EmployeeSocials;
using ApwPayroll_Domain.Entities.Employees.Trainings;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Domain.Entities.Leaves.LeaveResponseStatues;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypeRoles;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Domain.Entities.Menus;
using ApwPayroll_Domain.Entities.Menus.MenuTypes;
using ApwPayroll_Domain.Entities.Notifications;
using ApwPayroll_Domain.Entities.Notifications.NotificationListeners;
using ApwPayroll_Domain.Entities.Notifications.NotificationLogs;
using ApwPayroll_Domain.Entities.Notifications.NotificationTypes;
using ApwPayroll_Domain.Entities.ReferralDetails;
using ApwPayroll_Domain.Entities.RelationTypes;
using Domain.Entities.Templates.TemplateBodies;
using Domain.Entities.Templates.TemplateTypes;
using Domain.Entities.TemplateTags;
using Domain.Entities.TemplateTags.TemplateTagTypes;
using Domain.Models.Templates;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApwPayroll_Persistence.Data
{
    public class ApplicationDataContext : IdentityDbContext<AspUser>
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }
        public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();
        public DbSet<Document> Documents => Set<Document>();

        public DbSet<AddressType> AddressTypes => Set<AddressType>();

        public DbSet<Menu> Menu => Set<Menu>();
        public DbSet<MenuType> MenuTypes => Set<MenuType>();
        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<NotificationType> NotificationTypes => Set<NotificationType>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<NotificationLog> NotificationLogs => Set<NotificationLog>();
        public DbSet<NotificationListener> NotificationListeners => Set<NotificationListener>();

        public DbSet<Template> Templates => Set<Template>();
        public DbSet<TemplateBody> TemplateBody => Set<TemplateBody>();
        public DbSet<TemplateTag> TemplateTags => Set<TemplateTag>();
        public DbSet<TemplateTagType> TemplateTagTypes => Set<TemplateTagType>();
        public DbSet<TemplateType> TemplateTypes => Set<TemplateType>();
        public DbSet<Bank> Banks => Set<Bank>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<BranchAddress> BranchesAddresses => Set<BranchAddress>();
        public DbSet<BranchContact> BranchesContacts => Set<BranchContact>();
        public DbSet<BranchDocument> BranchesDocuments => Set<BranchDocument>();
        public DbSet<BranchDocumentType> BranchDocumentTypes => Set<BranchDocumentType>();
        public DbSet<BranchNumberFormat> BranchNumberFormats => Set<BranchNumberFormat>();
        public DbSet<Certificate> Certificates => Set<Certificate>();
        public DbSet<Checklist> Checklist => Set<Checklist>();
        public DbSet<EmployeeChecklist> EmployeeChecklists => Set<EmployeeChecklist>();
        public DbSet<ContactType> ContactTypes => Set<ContactType>();
        public DbSet<RelationType> RelationTypes => Set<RelationType>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Department> Departments => Set<Department>();

        public DbSet<EmergencyContact> EmergencyContacts => Set<EmergencyContact>();

        public DbSet<EmployeeAddress> EmployeeAddresses => Set<EmployeeAddress>();
        public DbSet<ReferralDetail> ReferralDetails => Set<ReferralDetail>();
        public DbSet<BankDetail> BankDetails => Set<BankDetail>();
        public DbSet<EmployeeDepartment> EmployeeDepartments => Set<EmployeeDepartment>();
        public DbSet<EmployeeDesignation> EmployeeDesignations => Set<EmployeeDesignation>();
        public DbSet<EmployeePersonalDetail> EmployeePersonalDetails => Set<EmployeePersonalDetail>();
        public DbSet<EmployeeDocument> EmployeeDocuments => Set<EmployeeDocument>();
        public DbSet<EmployeeDocumentType> EmployeeDocumentTypes => Set<EmployeeDocumentType>();
        public DbSet<EmployeeFamily> EmployeeFamilies => Set<EmployeeFamily>();
        public DbSet<EmployeeLanguage> EmployeeLanguages => Set<EmployeeLanguage>();
        public DbSet<EmployeeLicense> EmployeeLicenses => Set<EmployeeLicense>();

        public DbSet<EmployeeQualification> EmployeeQualifications => Set<EmployeeQualification>();
        public DbSet<EmployeeSocial> EmployeeSocials => Set<EmployeeSocial>();
        public DbSet<EmployeeExperience> EmployeeExperiences => Set<EmployeeExperience>();
        public DbSet<EmployeeContact> EmployeeContacts => Set<EmployeeContact>();
        public DbSet<Training> Training => Set<Training>();
        public DbSet<Holiday> Holidays => Set<Holiday>();
        public DbSet<HolidayType> HolidayTypes => Set<HolidayType>();
        public DbSet<Leave> Leaves => Set<Leave>();
        public DbSet<LeaveType> LeaveTypes => Set<LeaveType>();
        public DbSet<LeaveResponseStatus>LeaveResponseStatuses => Set<LeaveResponseStatus>();
        public DbSet<LeaveTypeRole> LeaveTypeRoles => Set<LeaveTypeRole>();
        public DbSet<HolidatTypeRole> HolidatTypeRoles => Set<HolidatTypeRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema("PayRolls");
        }
    }
}
