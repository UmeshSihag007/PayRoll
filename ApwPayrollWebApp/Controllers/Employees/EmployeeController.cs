using ApwPayroll_Application.Features.Banks.Queries.GetAllBanks;
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
 
            ModelState.Remove("Employee.DesignationId, ");
   
            if (ModelState.IsValid)
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

            return RedirectToAction("CreateEmployeeBasic");

        }




        #region  EmployeePersonalDetail Working...
        public async Task<IActionResult> CreateEmployeePersonal(int? employeeId)
        {
            await InitializeViewBags();
           return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployeePersonal(int? employeeId, EmployeeCreateViewModel command)
        {

            ModelState.Remove("EmployeePersonalDetail.ResidentialAddress.Nationality ");
            if (ModelState.IsValid)
            {
            if (HttpContext.Session.GetInt32("EmployeeId") != null)
            {
                employeeId= HttpContext.Session.GetInt32("EmployeeId");
            }

            var data = await _mediator.Send(new CreateEmployeePersonalDetailCommand(employeeId.Value, command.EmployeePersonalDetail));

            if (data.code == 200)
            {
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("CreateEmployeeEducation", "EmployeeEducation");
            }
            return RedirectToAction("CreateEmployeePersonal",command);

        }


 
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


 
        #endregion EmployeePersonalDetail Working... comeplete
         
 
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
            var accountType = EnumHelper.GetEnumValues<AccountTypeEnum>().ToList();
            var locations = await _mediator.Send(new GetAllLocationQuery());
            var country = locations.Data.Where(x => x.LocationType == LocationTypeEnum.Country).ToList();
            var bank = await _mediator.Send(new GetBankLookUpQuery());
            

            ViewBag.Country=country;
 
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





        public async Task<IActionResult> GetStatesByCountry(int countryId)
        {
            var locations = await _mediator.Send(new GetAllLocationQuery());
            var states = locations.Data
                .Where(x => x.LocationType == LocationTypeEnum.State && x.ParentId == countryId)
                .Select(x => new { x.Id, x.Name })
                .ToList();
            return Json(states);
        }

        public async Task<IActionResult> GetCitiesByState(int stateId)
        {
            var locations = await _mediator.Send(new GetAllLocationQuery());
            var cities = locations.Data
                .Where(x => x.LocationType == LocationTypeEnum.City && x.ParentId == stateId)
                .Select(x => new { x.Id, x.Name })
                .ToList();
            return Json(cities);
        }
    }
}
