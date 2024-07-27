using ApwPayroll_Application.Features.Banks.Commands.CreateBankCommands;
using ApwPayroll_Application.Features.Branches.Commands.CreateBranchCommands;
using ApwPayroll_Application.Features.Courses.Commands.CreateCourses;
using ApwPayroll_Application.Features.Departments.Commands.CreateDepartment;
using ApwPayroll_Application.Features.Designations.Commands.CreateDesignation;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.CreateHolidayTypes;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.CreateLeaveTypes;
using ApwPayroll_Application.Features.Locations.Commands.CreateLocations;

namespace ApwPayrollWebApp.Models;

public class MasterModel
{
    /* public int? EmployeeId { get; set; }*/
    public CreateLeaveTypeCommand createLeaveType { get; set; }
    public CreateHolidayTypeCommand createHolidayType { get; set; }
    public CreateBankCommand createBank {  get; set; }
    public CreateBranchCommand createBranch { get; set; }

    public CreateCoursesCommand createCourses { get; set; }
    public CreateDepartmentCommand createDepartment { get; set; }
    public CreateDesignationCommand createDesignation { get; set; }
}
