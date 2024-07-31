using ApwPayroll_Application.Features.Banks.Queries.GetAllBanks;
using ApwPayroll_Application.Features.Branches.Queries.GetAllBranches;
using ApwPayroll_Application.Features.Courses.Queries.GetAllCourses;
using ApwPayroll_Application.Features.Departments.Queries.GetAllDepartment;
using ApwPayroll_Application.Features.Designations.Queries.GetAllDesignation;
using ApwPayroll_Application.Features.Employees.EmployeeAddresses.Commands.CreateEmployeeAddress;
using ApwPayroll_Application.Features.Employees.EmployeeBankDetails.Commands.CreateEmployeeBankDetails;
using ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.CreateEmployeePersonalDetail;
using ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.UpdateEmployeePersonalDetail;
using ApwPayroll_Application.Features.Employees.Queries.GetByIdEmployee;
using ApwPayroll_Application.Features.Locations.Queries.GetAllLocations;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.AccountType;
using ApwPayroll_Domain.common.Enums.BloodGroup;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.LocationTypes;
using ApwPayroll_Domain.common.Enums.MarriedStatus;
using ApwPayroll_Domain.common.Enums.Salutation;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Domain.Entities.Banks.BankDetails;
using ApwPayroll_Domain.Entities.Employees.EmergencyContacts;
using ApwPayroll_Domain.Entities.Employees.EmployeeAddresses;
using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using ApwPayroll_Domain.Entities.RelationTypes;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.EnumHelpers;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeePersonalDetails
{
    public class EmployeePersonalDetailController : BaseController
    {
        private readonly IMediator _mediator;

        private readonly IGenericRepository<RelationType> _relationRepository;

        public EmployeePersonalDetailController(IMediator mediator, IGenericRepository<RelationType> relationRepository)
        {
            _mediator = mediator;
            _relationRepository = relationRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CreateEmployeePersonal(int? id)
        {
            await InitializeViewBags();
                var model = new EmployeeCreateViewModel();
            if (id != 0 && id != null)
            {
                var data = await _mediator.Send(new GetEmployeeByIdQuery(id.Value));
                var employee = data.Data;

                if (employee != null)
                {
                    var permanentAddress = employee.EmployeeAddresses?.FirstOrDefault(a => a.AddressTypeId == 1);
                    var residentialAddress = employee.EmployeeAddresses?.FirstOrDefault(a => a.AddressTypeId == 2);
                    var emergencyContact = employee.EmergencyContact?.FirstOrDefault();
                    var bankDetails = employee.BankDetails?.FirstOrDefault();

                    model.EmployeePersonalDetail = new CreateEmployeePersonalDetailDto
                    {
                        Id = employee.EmployeePersonalDetail?.EmployeeId ?? 0,
                         
                        BloodGroup = employee.EmployeePersonalDetail.BloodGroup,
                        DOB = employee.EmployeePersonalDetail.DOB,
                        Gender = employee.EmployeePersonalDetail.Gender,
                        FatherName = employee.EmployeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Father")?.Name,
                        FatherDOB = employee.EmployeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Father")?.DOB,
                        MotherName = employee.EmployeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Mother")?.Name,
                        MotherDOB = employee.EmployeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Mother")?.DOB,
                        MarriedStatus = employee.EmployeePersonalDetail.MarriedStatus,
                        SpouseName = employee.EmployeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Spouse")?.Name,
                        SpouseDOB = employee.EmployeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Spouse")?.DOB,
                        SpouseGender = employee.EmployeeFamily.FirstOrDefault(f => f.RelationType.Name == "Spouse").Gender,
                        DateOfWedding = employee.EmployeePersonalDetail?.DateOfWedding,
                        Emergency = emergencyContact != null ? new EmergencyContact
                        {
                            Name = emergencyContact.Name,
                            Email = emergencyContact.Email,
                            MobileNumber = emergencyContact.MobileNumber,
                            WhatsAppNumber = emergencyContact.WhatsAppNumber,
                            RelationTypeId=emergencyContact.RelationTypeId,
                        } : null,
                        PermanentAddress = permanentAddress != null ? new CreateEmployeeAddressCommand
                        {
                            Address1 = permanentAddress.Address1,
                            Address2 = permanentAddress.Address2,
                            Address3 = permanentAddress.Address3,
                            CityId = permanentAddress.CityId,
                            StateId = permanentAddress.StateId,
                            LocationId = permanentAddress.LocationId,
                            PinCode = permanentAddress.PinCode,
                            IsActive = permanentAddress.IsActive,
                            Nationality = permanentAddress.Nationality,
                            AddressTypeId = permanentAddress.AddressTypeId,
                            EmployeeId = permanentAddress.EmployeeId
                        } : null,
                        ResidentialAddress = residentialAddress != null ? new CreateEmployeeAddressCommand
                        {
                            Address1 = residentialAddress.Address1,
                            Address2 = residentialAddress.Address2,
                            Address3 = residentialAddress.Address3,
                            CityId = residentialAddress.CityId,
                            StateId = residentialAddress.StateId,
                            LocationId = residentialAddress.LocationId,
                            PinCode = residentialAddress.PinCode,
                            IsActive = residentialAddress.IsActive,
                            Nationality = residentialAddress.Nationality,
                            AddressTypeId = residentialAddress.AddressTypeId,
                            EmployeeId = residentialAddress.EmployeeId
                        } : null,
                        CreateEmployeeBank = bankDetails != null ? new CreateEmployeeBankDetailCommand
                        {
                            Id= bankDetails.Id,
                            AccountBranch = bankDetails.AccountBranch,
                            AccountName = bankDetails.AccountName,
                            AccountType = bankDetails.AccountType,
                            BanAccountId = bankDetails.BanAccountId,
                       BankId=bankDetails.BankId.Value,
                            IFCCode = bankDetails.IFCCode,
                            IsBankAccountVerified = bankDetails.IsBankAccountVerified,
                        } : null,
                        Religion = employee.EmployeePersonalDetail?.Religion,
                        PlaceOfBirth = employee.EmployeePersonalDetail?.PlaceOfBirth,
                    };
                }
                Notify(["Tesing"], null, 200);
            }
            await InitializeViewBags();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeePersonal(int? employeeId, EmployeeCreateViewModel command)
        {
            await InitializeViewBags();
            ModelState.Remove("EmployeePersonalDetail.ResidentialAddress.Nationality ");
            ModelState.Remove("EmployeePersonalDetail.PermanentAddress.EmployeeId");
            ModelState.Remove("EmployeePersonalDetail.ResidentialAddress.EmployeeId");
             if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetInt32("EmployeeId") != null)
                {
                    employeeId = HttpContext.Session.GetInt32("EmployeeId");
                }

                if(command.EmployeePersonalDetail.Id != null && command.EmployeePersonalDetail.Id!=0)
                {
                   var updateData=    await _mediator.Send(new UpdateEmployeePersonalDetailCommand(command.EmployeePersonalDetail.Id.Value, command.EmployeePersonalDetail));
                    if (HttpContext.Session.GetInt32("EmployeeId") != null)
                    {

                        return View(command);
                    }
                    return RedirectToAction("EmployeeCompleteDetails", "Employee", new { id = updateData.Data.EmployeeId });

                }
                var data = await _mediator.Send(new CreateEmployeePersonalDetailCommand(employeeId.Value, command.EmployeePersonalDetail));

                if (data.code == 200)
                {
                    Notify(data.Messages, null, data.code);
                }
                command = new EmployeeCreateViewModel();
         
                return RedirectToAction("CreateEmployeeEducation", "EmployeeEducation");
            }
            return View(command);
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
