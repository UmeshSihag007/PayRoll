﻿using ApwPayroll_Application.Features.Banks.Commands.CreateBankCommands;
using ApwPayroll_Application.Features.Branches.Commands.CreateBranchCommands;
using ApwPayroll_Application.Features.Courses.Commands.CreateCourses;
using ApwPayroll_Application.Features.Departments.Commands.CreateDepartment;
using ApwPayroll_Application.Features.Designations.Commands.CreateDesignation;
using ApwPayroll_Application.Features.DocumentTypes.Commands.CreateDocumentType;
using ApwPayroll_Application.Features.Employees.Commands.CreateEmployee;
 
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Commands.CreateEmployeeDocumentTypes;
 
using ApwPayroll_Application.Features.Employees.EmployeeAddresses.Commands.CreateEmployeeAddress;
using ApwPayroll_Application.Features.Employees.EmployeeBankDetails.Commands.CreateEmployeeBankDetails;
 
using ApwPayroll_Application.Features.Employees.EmployeeEducations.Commands.CreateEmployeeEducation;
using ApwPayroll_Application.Features.Employees.EmployeeExperiences.Commands.CreateEmployeeExperiences;
using ApwPayroll_Application.Features.Employees.EmployeeFamilies.Commands.CreateEmployeeFamily;
using ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.CreateEmployeePersonalDetail;
using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.CreateEmployeeReferences;
using ApwPayroll_Application.Features.Holidays.Commands.CreateHolidays;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.CreateHolidayTypes;
using ApwPayroll_Application.Features.Leaves.Commands.CreateLeaves;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.CreateLeaveTypes;
using ApwPayroll_Application.Features.Locations.Commands.CreateLocations;
using ApwPayroll_Application.Features.Menus.MenuTypes.Commands.CreateMenuType;
using ApwPayroll_Application.Features.Users.Commands.RegisterUsers;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Domain.Entities.Banks.BankDetails;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.Courses;
 
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
 
using ApwPayroll_Domain.Entities.Employees.EmployeeAddresses;
 
using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Domain.Entities.Locations;
using ApwPayroll_Domain.Entities.Menus.MenuTypes;
using ApwPayroll_Domain.Entities.ReferralDetails;
using AutoMapper;
using System.Reflection;

namespace ApwPayroll_Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

            //  custome  mapping work 
            CreateMap<CreateDocumentTypeCommand, DocumentType>();
            CreateMap<CreateMenuTypeCommand, MenuType>();
            CreateMap<CreateEmployeeCommand, Employee>();

            CreateMap<CreateEmployeeEducationCommand, EmployeeQualification>();
            CreateMap<CreateEmployeeExperiencesCommand, EmployeeExperience>();
            CreateMap<CreateEmployeeFamilyCommand, EmployeeFamily>();
            CreateMap<CreateEmployeeReferencesCommand, ReferralDetail>();
            CreateMap<CreateCoursesCommand, Course>();
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<CreateDesignationCommand, Designation>();

            CreateMap<CreateLocationCommand, Location>();
 
            CreateMap<CreateBranchCommand,Branch>();
            CreateMap<CreateHolidayTypeCommand,HolidayType>();
            CreateMap<CreateBankCommand,Bank>();
            CreateMap<CreateLeaveTypeCommand,LeaveType>();
            CreateMap< CreateEmployeePersonalDetailDto,EmployeePersonalDetail>();
            CreateMap<CreateEmployeeDocumentTypeCommand, EmployeeDocumentType>();
 




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

}
