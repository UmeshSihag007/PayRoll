using ApwPayroll_Application.Features.Branches.Queries.GetAllBranches;
using ApwPayroll_Application.Features.Courses.Queries.GetAllDepartments;
using ApwPayroll_Application.Features.Departments.Queries.GetAllDepartments;
using ApwPayroll_Application.Features.Designations.Queries.GetAllDesignations;
using ApwPayroll_Application.Features.Employees.Commands.CreateEmployee;
using ApwPayroll_Application.Features.Employees.Commands.UpdateEmployee;
using ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.CreateEmployeePersonalDetail;
using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.CreateEmployeeReferences;
using ApwPayroll_Application.Features.Employees.Queries.GetAllEmployees;
using ApwPayroll_Application.Features.Employees.Queries.GetByIdEmployee;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.BloodGroup;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.MarriedStatus;
using ApwPayroll_Domain.common.Enums.Salutation;
using ApwPayroll_Domain.Entities.RelationTypes;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.EnumHelpers;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees
{
    public class EmployeeController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RelationType> _relationRepository;

        public EmployeeController(IMediator mediator, IGenericRepository<RelationType> relationRepository)
        {
            _mediator = mediator;
            _relationRepository = relationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _mediator.Send(new GetAllEmployeeQuery());
            ViewBag.data = data.Data;
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _mediator.Send(new GetEmployeeByIdQuery(id));
            ViewBag.data = data.Data;

            return View(data);
        }



        public async Task<IActionResult> CreateEmployeeBasic()
        {
            await InitializeViewBags();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeBasic(EmployeeCreateViewModel command)
        {
            var data = await _mediator.Send(command.Employee);
            TempData["EmployeeId"] = data.Data.Id;

            if (data.code == 200)
            {
                Notify(data.Messages, null, data.code);
            }

            HttpContext.Session.SetInt32("EmployeeId", data.Data.Id);
            return RedirectToAction("CreateEmployeePersonal", new { employeeId = data.Data.Id });
        }

        public async Task<IActionResult> CreateEmployeePersonal(int? employeeId)
        {

            ViewBag.employeeId = employeeId;
            await InitializeViewBags();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployeePersonal(int? employeeId, EmployeeCreateViewModel command)
        {



            var data = await _mediator.Send(new CreateEmployeePersonalDetailCommand((int)employeeId, command.EmployeePersonalDetail));

            if (data.code == 200)
            {
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("CreateEmployeeEducation", "EmployeeEducation");

        }

        public async Task<IActionResult> CreateEducationQualification(int? employeeId)
        {
            ViewBag.employeeId = employeeId;
            await InitializeViewBags();
            return View();
        }



        public async Task<IActionResult> EmployeeFamilyDetail()
        {
            await InitializeViewBags();
            return View();
        }
        public async Task<IActionResult> EmployeeDocument()
        {
            await InitializeViewBags();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeDocument(EmployeeCreateViewModel command)
        {



            await _mediator.Send(command.documentCommand);
            return View();
        }
         
        public async Task<IActionResult> EmployeeReference(int?employeeId)
        {
            await InitializeViewBags();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeReference(EmployeeCreateViewModel command)
        {
            command.EmployeeId = 1;
            await _mediator.Send( command.ReferencesCommand);
            /*await _mediator.Send(command.ReferencesCommand);*/
            return View();
        }



        [HttpGet]
        public IActionResult CreateEmployeePersonalDetail()
        {
            int employeeId = (int)TempData["EmployeeId"];
            ViewBag.EmployeeId = employeeId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(int id, CreateEmployeeCommand command)
        {
            var data = await _mediator.Send(new UpdateEmployeeCommand(id, command));
            return View(data);
        }


        private async Task InitializeViewBags()
        {
            var branches = await _mediator.Send(new GetAllBranchQuery());
            var designation = await _mediator.Send(new GetAllDesignationQuery());
            var departments = await _mediator.Send(new GetAllDepartmentQuery());
            var course = await _mediator.Send(new GetAllCoursesQuery());
            var relationType = await _relationRepository.GetAllAsync();
            var genderLookup = EnumHelper.GetEnumValues<GenderEnum>().ToList();
            var bloodGroup = EnumHelper.GetEnumValues<BloodGroupEnum>().ToList();
            var salutationLookup = EnumHelper.GetEnumValues<SalutationEnum>().ToList();
            var martialStatus = EnumHelper.GetEnumValues<MarriedStatusEnum>().ToList();

            ViewBag.relationType = relationType;
            ViewBag.designation = designation.Data;
            ViewBag.departments = departments.Data;
            ViewBag.bloodGroup = bloodGroup;
            ViewBag.martialStatus = martialStatus;
            ViewBag.branches = branches.Data;
            ViewBag.GenderLookup = genderLookup;
            ViewBag.SalutationLookup = salutationLookup;
            ViewBag.Course = course.Data;
        }
    }
}
