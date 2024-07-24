using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.CreateEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.CreateEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDesignations.Commands.CreateEmployeeDesignation;

namespace ApwPayrollWebApp.Models;

public class EmployeeProfileModel
{
   /* public int? EmployeeId { get; set; }*/

    public CreateEmployeeCoursesCommand createCourses { get; set; }
    public CreateEmployeeDepartmentCommand createDepartment { get; set; }
    public CreateEmployeeDesignationCommand createDesignation { get; set; }
}
