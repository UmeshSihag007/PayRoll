using ApwPayroll_Application.Features.Banks.Commands.CreateBankCommands;
using ApwPayroll_Application.Features.Branches.Commands.CreateBranchCommands;
using ApwPayroll_Application.Features.Courses.Commands.CreateCourses;
using ApwPayroll_Application.Features.Departments.Commands.CreateDepartment;
using ApwPayroll_Application.Features.Designations.Commands.CreateDesignation;

namespace ApwPayrollWebApp.Models;

public class MasterModel
{
    /* public int? EmployeeId { get; set; }*/

    public CreateBankCommand createBank {  get; set; }
    public CreateBranchCommand createBranch { get; set; }

    public CreateCoursesCommand createCourses { get; set; }
    public CreateDepartmentCommand createDepartment { get; set; }
    public CreateDesignationCommand createDesignation { get; set; }
}
