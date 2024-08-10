using ApwPayroll_Application.Contracts.Dtos;
using ApwPayroll_Application.Features.Banks.Commands.CreateBankCommands;
using ApwPayroll_Application.Features.Banks.Queries.GetAllBanks;
using ApwPayroll_Application.Features.Branches.Commands.CreateBranchCommands;
using ApwPayroll_Application.Features.Branches.Queries.GetAllBranches;
using ApwPayroll_Application.Features.Courses.Commands.CreateCourses;
using ApwPayroll_Application.Features.Departments.Commands.CreateDepartment;
using ApwPayroll_Application.Features.Designations.Commands.CreateDesignation;
using ApwPayroll_Application.Features.DocumentTypes.Commands.CreateDocumentType;
using ApwPayroll_Application.Features.Employees.Commands.CreateEmployee;
using ApwPayroll_Application.Features.Employees.EmployeeEducations.Commands.CreateEmployeeEducation;
using ApwPayroll_Application.Features.Employees.EmployeeExperiences.Commands.CreateEmployeeExperiences;
using ApwPayroll_Application.Features.Employees.EmployeeFamilies.Commands.CreateEmployeeFamily;
using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.CreateEmployeeReferences;
using ApwPayroll_Application.Features.Employees.Queries.GetAllEmployees;
using ApwPayroll_Application.Features.Holidays.Commands.CreateHolidays;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.CreateHolidayTypes;
using ApwPayroll_Application.Features.Leaves.Commands.CreateLeaves;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.CreateLeaveTypes;
using ApwPayroll_Application.Features.Locations.Commands.CreateLocations;
using ApwPayroll_Application.Features.Locations.Queries.GetAllLocations;
using ApwPayroll_Application.Features.Menus.MenuTypes.Commands.CreateMenuType;
using ApwPayroll_Application.Features.Users.Commands.RegisterUsers;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Domain.Entities.Holidays.HolidatTypeRuleLocations;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Domain.Entities.Locations;
using ApwPayroll_Domain.Entities.Menus.MenuTypes;
using ApwPayroll_Domain.Entities.ReferralDetails;
using AutoMapper;
using System.Reflection;

namespace ApwPayroll_Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        //  custome  mapping work 
        CreateMap<CreateLocationCommand, Location>();
        CreateMap<Location, GetAllLocationDto>();
        CreateMap<CreateBranchCommand, Branch>();
        CreateMap<Branch, GetBranchDto>();
        CreateMap<CreateHolidayTypeCommand, HolidayType>();

        CreateMap<CreateHolidayCommand, Holiday>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Holiday, GetHolidayRuleDto>();
        CreateMap<HolidayTypeRule, GetHolidayRuleDto>();
        CreateMap<HolidayTypeRuleLocation, GetHolidayRuleDto>();

        CreateMap<CreateLeaveCommand, Leave>();

        CreateMap<Bank, GetBankDto>();
        CreateMap<Bank, LookUpDto>();
        CreateMap<Branch, LookUpDto>();
        CreateMap<CreateBankCommand, Bank>();
        CreateMap<CreateLeaveTypeCommand, LeaveType>();
        CreateMap<CreateDocumentTypeCommand, DocumentType>();
        CreateMap<CreateMenuTypeCommand, MenuType>();
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<Employee, GetEmployeeDto>();

        CreateMap<CreateEmployeeEducationCommand, EmployeeQualification>();
        CreateMap<CreateEmployeeExperiencesCommand, EmployeeExperience>();
        CreateMap<CreateEmployeeFamilyCommand, EmployeeFamily>();
        CreateMap<CreateEmployeeReferencesCommand, ReferralDetail>();
        CreateMap<CreateCoursesCommand, Course>();
        CreateMap<CreateDepartmentCommand, Department>();
        CreateMap<CreateDesignationCommand, Designation>();

        CreateMap<RegisterUserCommand, AspUser>()
        .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
    }
    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var mapFromType = typeof(IMapFrom<>);

        var mappingMethodName = nameof(IMapFrom<object>.Mapping);

        bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;

        var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

        var argumentTypes = new Type[] { typeof(Profile) };

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod(mappingMethodName);

            if (methodInfo != null)
            {
                methodInfo.Invoke(instance, new object[] { this });
            }
            else
            {
                var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                if (interfaces.Count > 0)
                {
                    foreach (var @interface in interfaces)
                    {
                        var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);
                        interfaceMethodInfo.Invoke(instance, new object[] { this });
                    }
                }
            }
        }
    }
}



