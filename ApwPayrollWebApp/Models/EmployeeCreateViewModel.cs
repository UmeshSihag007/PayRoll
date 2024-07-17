using ApwPayroll_Application.Features.Employees.Commands.CreateEmployee;
 
using ApwPayroll_Application.Features.Employees.EmployeeEducations.Commands.CreateEmployeeEducation;
 
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.Commands.CreateEmployeeDocuments;
 
using ApwPayroll_Application.Features.Employees.EmployeeExperiences.Commands.CreateEmployeeExperiences;
using ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.CreateEmployeePersonalDetail;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Application.Features.Employees.EmployeeFamilies.Commands.CreateEmployeeFamily;

namespace ApwPayrollWebApp.Models;


public class EmployeeCreateViewModel
{
    public int? EmployeeId { get; set; }
    public CreateEmployeeCommand? Employee { get; set; }
    public CreateEmployeePersonalDetailDto? EmployeePersonalDetail { get; set; }

    public CreateEmployeeEducationCommand? Qualification { get; set; }
    public CreateEmployeeExperiencesCommand? Experiences { get; set; }

    public CreateEmployeeDocumentCommand? documentCommand { get; set; }
    public CreateEmployeeFamilyCommand?  CreateEmployeeFamily { get; set; }

 
   

 
}