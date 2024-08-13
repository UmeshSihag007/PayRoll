using Amazon.Runtime.Internal.Util;
using ApwPayroll_Application.Features.Banks.Queries.GetAllBanks;
using ApwPayroll_Application.Features.Branches.Queries.GetAllBranches;
using ApwPayroll_Application.Features.Courses.Queries.GetAllCourses;
using ApwPayroll_Application.Features.Departments.Queries.GetAllDepartment;
using ApwPayroll_Application.Features.Designations.Queries.GetAllDesignation;
using ApwPayroll_Application.Features.Employees.Commands.CreateEmployee;
using ApwPayroll_Application.Features.Employees.Commands.UpdateEmployee;
using ApwPayroll_Application.Features.Employees.Commands.UpdateIsLoginAccess;
using ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.CreateEmployeePersonalDetail;
using ApwPayroll_Application.Features.Employees.Queries.GetAllEmployees;
using ApwPayroll_Application.Features.Employees.Queries.GetByIdEmployee;
using ApwPayroll_Application.Features.Employees.Queries.SearchEmployee;
using ApwPayroll_Application.Features.Locations.Queries.GetAllLocations;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.AccountType;
using ApwPayroll_Domain.common.Enums.BloodGroup;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.LocationTypes;
using ApwPayroll_Domain.common.Enums.MarriedStatus;
using ApwPayroll_Domain.common.Enums.Salutation;
using ApwPayroll_Domain.Entities.RelationTypes;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.EnumHelpers;
using ApwPayrollWebApp.Models;
using Google.Rpc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RelationType> _relationRepository;

        public EmployeeController(IMediator mediator, IGenericRepository<RelationType> relationRepository)
        {
            _mediator = mediator;
            _relationRepository = relationRepository;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 40, SearchEmployeeDto? searchEmployee = default)
        {
            await InitializeViewBags();
            ModelState.Remove("searchEmployee.BranchId");
            if (ModelState.IsValid)
            {
                var query = new GetAllEmployeeQuery(pageNumber, pageSize, searchEmployee);
                var result = await _mediator.Send(query);

                if (!result.succeeded)
                {
                    return NotFound();
                }

                var viewModel = new EmployeeIndexViewModel
                {
                    Employees = result.Data.Data,
                    Pagination = new PaginationViewModel
                    {
                        CurrentPage = result.Data.CurrentPage,
                        TotalPages = result.Data.TotalPages,
                        PageSize = result.Data.PageSize
                    },
                    SearchEmployee = searchEmployee
                };

                return View(viewModel);
            }
            return View();
        }
        public async Task<IActionResult> EmployeeCompleteDetails(int id)
        {
            var model = new EmployeeCreateViewModel();


            var data = await _mediator.Send(new GetEmployeeByIdQuery(id));
            if (data.succeeded)
            {

                ViewBag.employee = data.Data;
            }

            return View(model);
        }

        public async Task<IActionResult> EmployeeDetailInResume(int id)
        {
            var model = new EmployeeCreateViewModel();
            var data = await _mediator.Send(new GetEmployeeByIdQuery(id));

            if (data.succeeded)
            {
                var designation = data.Data.EmployeeDesignations.FirstOrDefault()?.Designation;
                var department = data.Data.EmployeeDepartments.FirstOrDefault()?.Department;
                var address1 = data.Data.EmployeeAddresses.FirstOrDefault(x => x.AddressTypeId == 1);
                var address2 = data.Data.EmployeeAddresses.FirstOrDefault(x => x.AddressTypeId == 2);
                var bank = data.Data.BankDetails.FirstOrDefault()?.Bank;

                ViewBag.employee = data.Data;
                ViewBag.designation = designation;
                ViewBag.department = department;
                ViewBag.permanent = address1;
                ViewBag.residential = address2;
                ViewBag.bank = bank;
            }
            else
            {
                return View("Error"); // Handle the case where the query was not successful
            }

            return View(model);
        }




        public async Task<IActionResult> CreateEmployeeBasic(int? id)
        {
            await InitializeViewBags();
            var model = new EmployeeCreateViewModel();
            if (id.HasValue)
            {
                var employee = await _mediator.Send(new GetEmployeeByIdQuery(id.Value));

                // Assuming 'employee' is an object of GetEmployeeDto type
                model.Employee = new CreateEmployeeCommand()
                {
                    Id = employee.Data.Id,
                    FirstName = employee.Data.FirstName,
                    LastName = employee.Data.LastName,
                    ESINumber = employee.Data.ESINumber,
                    PfNumber = employee.Data.PfNumber,
                    DateOfJoining = employee.Data.DateOfJoining,
                    InsuranceNumber = employee.Data.InsuranceNumber,
                    MobileNumber = employee.Data.MobileNumber,
                    EmailId = employee.Data.EmailId,
                    UserId = employee.Data.UserId,
                    IsBrokerExamPass = employee.Data.IsBrokerExamPass,
                    StartedSalary = employee.Data.StartedSalary,
                    Salutation = employee.Data.Salutation,
                    BranchId = employee.Data.BranchId,
                    IsLoginAccess = employee.Data.IsLoginAccess,
                    PanNumber = employee.Data.PanNumber,
                    AadharNumber = employee.Data.AadharNumber,
                    RationCardNumber = employee.Data.RationCardNumber,
                    PassportNumber = employee.Data.PassportNumber,
                    VoterId = employee.Data.VoterId,
                    LicenceNumber = employee.Data.LicenceNumber,
                    UanNumber = employee.Data.UanNumber,
                    DesignationId = employee.Data.EmployeeDesignations.FirstOrDefault()?.DesignationId ?? 0,
                    DepartmentId = employee.Data.EmployeeDepartments.FirstOrDefault()?.DepartmentId ?? 0
                };
            }
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeBasic(EmployeeCreateViewModel command)
        {


            if (ModelState.IsValid)
            {

                if (command.Employee?.Id != 0 && command.Employee?.Id != null)
                {

                    var data = await _mediator.Send(new UpdateEmployeeCommand(command.Employee.Id.Value, command.Employee));

                    if (data.succeeded)
                    {

                        Notify(data.Messages, null, data.code);
                        return RedirectToAction("EmployeeCompleteDetails", new { id = command.Employee.Id });
                    }
                    else
                    {
                        Notify(data.Messages, null, data.code);
                    }

                }
                else
                {

                    var data = await _mediator.Send(command.Employee);
                    //TempData["EmployeeId"] = data.Data.Id;

                    if (data.code == 200)
                    {
                        Notify(data.Messages, null, data.code);
                    }

                    else
                    {

                        await InitializeViewBags();
                        Notify(data.Messages, null, data.code);
                        return View(command);
                    }
                    HttpContext.Session.SetInt32("EmployeeId", data.Data.Id);
                    return RedirectToAction("CreateEmployeePersonal", "EmployeePersonalDetail", new { employeeId = data.Data.Id });
                }

            }

            await InitializeViewBags();
            return View(command);

        }






        [HttpGet]
        public IActionResult CreateEmployeePersonalDetail()
        {
            int employeeId = (int)TempData["EmployeeId"];
            ViewBag.EmployeeId = employeeId;
            return View();
        }



        #region UPDATE  LOGIN ACCESS   
        [HttpPost]
        public async Task<IActionResult> UpdateLoginAccess(int id, bool isActive)
        {
            var data = await _mediator.Send(new UpdateIsLoginAccessCommand(id, isActive));
            if (data.code == 200)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }

            return Json(new { success = true });
        }
        #endregion


        private async Task InitializeViewBags()
        {
            var branches = await _mediator.Send(new GetAllBranchQuery());
            var designation = await _mediator.Send(new GetAllDesignationQuery());
            var departments = await _mediator.Send(new GetAllDepartmentQuery());
            var course = await _mediator.Send(new GetCoursesQuery());
            var relationType = await _relationRepository.GetAllAsync();
            var genderLookup = EnumHelper.GetEnumValues<GenderEnum>().ToList();
            var bloodGroup = EnumHelper.GetEnumValues<BloodGroupEnum>().ToList();
            var salutationLookup = EnumHelper.GetEnumValues<SalutationEnum>().ToList();
            var martialStatus = EnumHelper.GetEnumValues<MarriedStatusEnum>().ToList();
            var accountType = EnumHelper.GetEnumValues<AccountTypeEnum>().ToList();
            var locations = await _mediator.Send(new GetAllLocationQuery());
            var country = locations.Data.Where(x => x.LocationType == LocationTypeEnum.Country).ToList();
            var bank = await _mediator.Send(new GetBankLookUpQuery());


            ViewBag.Country = country;

            ViewBag.relationType = relationType;
            ViewBag.Bank = bank.Data;
            ViewBag.designation = designation.Data;
            ViewBag.departments = departments.Data;
            ViewBag.bloodGroup = bloodGroup;
            ViewBag.martialStatus = martialStatus;
            ViewBag.AccountType = accountType;
            ViewBag.branches = branches.Data;
            ViewBag.GenderLookup = genderLookup;
            ViewBag.SalutationLookup = salutationLookup;
            ViewBag.Course = course.Data;
        }



    }
}
