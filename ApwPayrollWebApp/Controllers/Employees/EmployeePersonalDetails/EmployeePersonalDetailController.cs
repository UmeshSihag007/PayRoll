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
using ApwPayroll_Domain.common.Enums.Religions;
using ApwPayroll_Domain.common.Enums.Salutation;
using ApwPayroll_Domain.Entities.Employees.EmergencyContacts;
using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using ApwPayroll_Domain.Entities.Locations;
using ApwPayroll_Domain.Entities.RelationTypes;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.EnumHelpers;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeePersonalDetails
{
    public class EmployeePersonalDetailController : BaseController
    {
        private readonly IMediator _mediator;

        private readonly IGenericRepository<RelationType> _relationRepository;
        private readonly IGenericRepository<Location> _locationRepository;

        public EmployeePersonalDetailController(IMediator mediator, IGenericRepository<RelationType> relationRepository, IGenericRepository<Location> loctionRepository)
        {
            _mediator = mediator;
            _relationRepository = relationRepository;
            _locationRepository = loctionRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateEmployeePersonal(int? id)
        {
            ViewBag.employeeId = id;
            await InitializeViewBags();

            var model = new EmployeeCreateViewModel();

            if (!id.HasValue || id.Value == 0)
            {
                return View(model);
            }

            var data = await _mediator.Send(new GetEmployeeByIdQuery(id.Value));
            var employee = data?.Data;

            if (employee?.EmployeePersonalDetail == null)
            {
                return View(model);
            }

            var employeePersonalDetail = employee.EmployeePersonalDetail;
            var employeeFamily = employee.EmployeeFamily;

            var permanentAddress = employee.EmployeeAddresses?.FirstOrDefault(a => a.AddressTypeId == 1);
            var residentialAddress = employee.EmployeeAddresses?.FirstOrDefault(a => a.AddressTypeId == 2);
            var emergencyContact = employee.EmergencyContact?.FirstOrDefault();
            var bankDetails = employee.BankDetails?.FirstOrDefault();
            var spouse = employeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Spouse");

            var residentialCity = await GetLocationWithParentsAsync(residentialAddress?.LocationId);
            var permanentCity = await GetLocationWithParentsAsync(permanentAddress?.LocationId);
 
            model.EmployeePersonalDetail = new CreateEmployeePersonalDetailDto
            {
                Id = employeePersonalDetail.EmployeeId,

                BloodGroup = employeePersonalDetail.BloodGroup,
                DOB = employeePersonalDetail.DOB,
                Gender = employeePersonalDetail.Gender,
                FatherName = employeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Father")?.Name,
                FatherDOB = employeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Father")?.DOB,
                MotherName = employeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Mother")?.Name,
                MotherDOB = employeeFamily?.FirstOrDefault(f => f.RelationType.Name == "Mother")?.DOB,
                MarriedStatus = employeePersonalDetail.MarriedStatus,
                SpouseName = spouse?.Name,
                SpouseDOB = spouse?.DOB,
                SpouseGender = spouse?.Gender,
                DateOfWedding = employeePersonalDetail?.DateOfWedding,

                Emergency = emergencyContact != null ? new EmergencyContact
                {
                    Name = emergencyContact.Name,
                    Email = emergencyContact.Email,
                    MobileNumber = emergencyContact.MobileNumber,
                    WhatsAppNumber = emergencyContact.WhatsAppNumber,
                    RelationTypeId = emergencyContact.RelationTypeId
                } : null,

                PermanentAddress = permanentAddress != null ? new CreateEmployeeAddressCommand
                {
                    Address1 = permanentAddress.Address1,
                    Address2 = permanentAddress.Address2,
                    Address3 = permanentAddress.Address3,
                    CityId = permanentCity?.Id,
                    StateId = permanentCity?.ParentId,
                    CountryId=permanentCity?.Parent?.ParentId,
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
                    CityId = residentialCity?.Id,
                    StateId = residentialCity?.ParentId,
                    LocationId = residentialCity?.Id,
                    PinCode = residentialAddress.PinCode,
                    CountryId = residentialCity?.Parent?.ParentId,
                    IsActive = residentialAddress.IsActive,
                    Nationality = residentialAddress.Nationality,
                    AddressTypeId = residentialAddress.AddressTypeId,
                    EmployeeId = residentialAddress.EmployeeId
                } : null,

                CreateEmployeeBank = bankDetails != null ? new CreateEmployeeBankDetailCommand
                {
                    Id = bankDetails.Id,
                    AccountBranch = bankDetails.AccountBranch,
                    AccountName = bankDetails.AccountName,
                    AccountType = bankDetails.AccountType,
                    BanAccountId = bankDetails.BanAccountId,
                    BankId = bankDetails.BankId ?? default,
                    IFCCode = bankDetails.IFCCode,
                    IsBankAccountVerified = bankDetails.IsBankAccountVerified
                } : null,

                Religion = employeePersonalDetail?.Religion,
                PlaceOfBirth = employeePersonalDetail?.PlaceOfBirth,
            };
 

            return View(model);
        }

  

        [HttpPost]
        public async Task<IActionResult> CreateEmployeePersonal(int? employeeId, EmployeeCreateViewModel command)
        {
            await InitializeViewBags();

            if (HttpContext.Session.GetInt32("EmployeeId") != null)
            {
                employeeId = HttpContext.Session.GetInt32("EmployeeId");
            }
            ModelState.Remove("EmployeePersonalDetail.PermanentAddress.EmployeeId");
            ModelState.Remove("EmployeePersonalDetail.ResidentialAddress.EmployeeId");
            ModelState.Remove("EmployeePersonalDetail.PermanentAddress.CountryId");
            ModelState.Remove("EmployeePersonalDetail.ResidentialAddress.CountryId");


            if (ModelState.IsValid)
            {


                if (command.EmployeePersonalDetail.Id != null && command.EmployeePersonalDetail.Id != 0)
                {
                    var updateData = await _mediator.Send(new UpdateEmployeePersonalDetailCommand(command.EmployeePersonalDetail.Id.Value, command.EmployeePersonalDetail));
 
                    if (HttpContext.Session.GetInt32("EmployeeId") != null)
                    {

                        return View(command);
                    }
                    if (updateData.code == 200)
                    {
                        Notify(updateData.Messages, null, updateData.code);
                    }
                    else
                    {
                        Notify(updateData.Messages, null, updateData.code);
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

                if (HttpContext.Session.GetInt32("EmployeeId") != null)
                {

                    return RedirectToAction("CreateEmployeeEducation", "EmployeeEducation");

                }

                return RedirectToAction("EmployeeCompleteDetails", "Employee", new { id = employeeId });

            }
            return View(command);
        }




        public async Task<IActionResult> GetStatesByCountry(int countryId)
        {
            var locations = await _mediator.Send(new GetAllLocationQuery());
            var states = locations.Data
                .Where(x => x.LocationType == LocationTypeEnum.State && x.ParentId == countryId)

                .ToList();
            return Json(states);
        }
        [HttpGet]
        public async Task<IActionResult> GetCitiesByState(int stateId)
        {
            var locations = await _mediator.Send(new GetAllLocationQuery());
            var cities = locations.Data
                .Where(x => x.LocationType == LocationTypeEnum.City && x.ParentId == stateId)

                .ToList();
            return Json(cities);
        }
        [HttpGet]
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
            var religionLookUp = EnumHelper.GetEnumValues<ReligionEnum>().ToList();


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
            ViewBag.Religion = religionLookUp;
        }




        private async Task<Location> GetLocationWithParentsAsync(int? locationId)
        {
            if (!locationId.HasValue)
            {
                return null;
            }

            var city = await _locationRepository.Entities
                .Include(x => x.Parent)
                .FirstOrDefaultAsync(x => x.Id == locationId.Value);

            if (city?.Parent == null)
            {
                return city;
            }

            var state = await _locationRepository.Entities
                .Include(x => x.Parent)
                .FirstOrDefaultAsync(x => x.Id == city.ParentId);

            if (state?.Parent == null)
            {
                return city;
            }

            var country = await _locationRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == state.ParentId);

            city.Parent.Parent = country;

            return city;
        }

    }


}
