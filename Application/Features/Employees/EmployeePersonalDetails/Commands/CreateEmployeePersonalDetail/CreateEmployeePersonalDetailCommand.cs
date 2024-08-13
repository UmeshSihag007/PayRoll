using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.Gender;

using ApwPayroll_Domain.Entities.Banks.BankDetails;
using ApwPayroll_Domain.Entities.Employees.EmergencyContacts;
using ApwPayroll_Domain.Entities.Employees.EmployeeAddresses;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.CreateEmployeePersonalDetail
{
    public class CreateEmployeePersonalDetailCommand : IRequest<Result<int>>
    {
        public CreateEmployeePersonalDetailCommand(int employeeId, CreateEmployeePersonalDetailDto createEmployeePersonals)
        {
            EmployeeId = employeeId;
            CreateEmployeePersonals = createEmployeePersonals;
        }

        public int EmployeeId { get; set; }
        public CreateEmployeePersonalDetailDto CreateEmployeePersonals { get; set; }
     

    }
    internal class CreateEmployeePersonalDetailCommandHandler : IRequestHandler<CreateEmployeePersonalDetailCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateEmployeePersonalDetailCommandHandler(IUnitOfWork unitOfWork = null)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CreateEmployeePersonalDetailCommand request, CancellationToken cancellationToken)
        {
            var personalData = new EmployeePersonalDetail
            {
                EmployeeId = request.EmployeeId,
                BloodGroup = request.CreateEmployeePersonals.BloodGroup,
                DateOfWedding = request.CreateEmployeePersonals.DateOfWedding,
                DOB = request.CreateEmployeePersonals.DOB,
                Gender = request.CreateEmployeePersonals.Gender,
                MarriedStatus = request.CreateEmployeePersonals.MarriedStatus,
                PlaceOfBirth = request.CreateEmployeePersonals.PlaceOfBirth,
                Religion = request.CreateEmployeePersonals.Religion,
                IsActive = true
            };
            await _unitOfWork.Repository<EmployeePersonalDetail>().AddAsync(personalData);
            await _unitOfWork.Save(cancellationToken);
            //family
            if (request.CreateEmployeePersonals.FatherName != null || request.CreateEmployeePersonals.FatherDOB != null)
            {
                var fatherData = new EmployeeFamily
                {
                    Name = request.CreateEmployeePersonals.FatherName,
                    EmployeeId = request.EmployeeId,
                    DOB = request.CreateEmployeePersonals.DOB,
                    Gender = GenderEnum.Male,
                    RelationTypeId = 1,
                    IsActive = true,
                };
                await _unitOfWork.Repository<EmployeeFamily>().AddAsync(fatherData);
                await _unitOfWork.Save(cancellationToken);
            }
            if (request.CreateEmployeePersonals.MotherName != null || request.CreateEmployeePersonals.MotherDOB != null)
            {
                var motherData = new EmployeeFamily
                {
                    Name = request.CreateEmployeePersonals.MotherName,
                    EmployeeId = request.EmployeeId,
                    DOB = request.CreateEmployeePersonals.DOB,
                    Gender = GenderEnum.Male,
                    RelationTypeId = 2,
                    IsActive = true,
                };
                await _unitOfWork.Repository<EmployeeFamily>().AddAsync(motherData);
                await _unitOfWork.Save(cancellationToken);

            }
            if (request.CreateEmployeePersonals.SpouseName != null || request.CreateEmployeePersonals.SpouseDOB != null)
            {
                var SpouseData = new EmployeeFamily
                {
                    Name = request.CreateEmployeePersonals.SpouseName,
                    EmployeeId = request.EmployeeId,
                    DOB = request.CreateEmployeePersonals.DOB,
                    Gender = request.CreateEmployeePersonals.SpouseGender,
                    RelationTypeId = 4,
                    IsActive = true,
                };
                await _unitOfWork.Repository<EmployeeFamily>().AddAsync(SpouseData);
                await _unitOfWork.Save(cancellationToken);
            }

            // address  working 
            if (request.CreateEmployeePersonals.PermanentAddress != null)
            {
                var permanentAddress = new EmployeeAddress
                {
                    Address1 = request.CreateEmployeePersonals.PermanentAddress.Address1,
                    Address2 = request.CreateEmployeePersonals.PermanentAddress.Address2,
                    Address3 = request.CreateEmployeePersonals.PermanentAddress.Address3,
                    PinCode= request.CreateEmployeePersonals.PermanentAddress.PinCode,
                    AddressTypeId = 1,
                    EmployeeId = request.EmployeeId,
                    Nationality = request.CreateEmployeePersonals.PermanentAddress.Nationality,
                    IsActive = true,

                    CityId = request.CreateEmployeePersonals.PermanentAddress.CityId,
                    StateId = request.CreateEmployeePersonals.PermanentAddress.StateId,
                };
                await _unitOfWork.Repository<EmployeeAddress>().AddAsync(permanentAddress);
                await _unitOfWork.Save(cancellationToken);
            }

            // address  working 
            if (request.CreateEmployeePersonals.ResidentialAddress != null)
            {
                var residentialAddress = new EmployeeAddress
                {
                    Address1 = request.CreateEmployeePersonals.ResidentialAddress.Address1,
                    Address2 = request.CreateEmployeePersonals.ResidentialAddress.Address2,
                    Address3 = request.CreateEmployeePersonals.ResidentialAddress.Address3,
                    PinCode = request.CreateEmployeePersonals.ResidentialAddress.PinCode,
                    AddressTypeId = 2,
                    EmployeeId = request.EmployeeId,
                    Nationality = request.CreateEmployeePersonals.ResidentialAddress.Nationality,
                    IsActive = true,
                    CityId = request.CreateEmployeePersonals.ResidentialAddress.CityId,
                    StateId = request.CreateEmployeePersonals.ResidentialAddress.StateId,

                };
                await _unitOfWork.Repository<EmployeeAddress>().AddAsync(residentialAddress);
                await _unitOfWork.Save(cancellationToken);
            }

            //Emergency Contact working
            if (request.CreateEmployeePersonals.Emergency != null)
            {
                var emergencyContact = new EmergencyContact
                {
                    Name = request.CreateEmployeePersonals.FatherName ?? "Testing",
                    RelationTypeId = request.CreateEmployeePersonals.Emergency.RelationTypeId,
                    Email = request.CreateEmployeePersonals.Emergency.Email,
                    MobileNumber = request.CreateEmployeePersonals.Emergency.MobileNumber,
                    WhatsAppNumber = request.CreateEmployeePersonals.Emergency.WhatsAppNumber,
                    EmployeeId = request.EmployeeId,
                };
                await _unitOfWork.Repository<EmergencyContact>().AddAsync(emergencyContact);
                await _unitOfWork.Save(cancellationToken);
            }



            // Bank Detail working

            if (request.CreateEmployeePersonals.CreateEmployeeBank != null)
            {
                var bankDetail = new BankDetail
                {
                    BankId = request.CreateEmployeePersonals.CreateEmployeeBank.BankId,
                    IFCCode = request.CreateEmployeePersonals.CreateEmployeeBank.IFCCode,
                    AccountName = request.CreateEmployeePersonals.CreateEmployeeBank.AccountName,
                    AccountBranch = request.CreateEmployeePersonals.CreateEmployeeBank.AccountBranch,
                    BanAccountId = request.CreateEmployeePersonals.CreateEmployeeBank.BanAccountId,
                    AccountType=request.CreateEmployeePersonals.CreateEmployeeBank.AccountType,
                    EmployeeId = request.EmployeeId,


                };
                await _unitOfWork.Repository<BankDetail>().AddAsync(bankDetail);
                await _unitOfWork.Save(cancellationToken);
            }


            return Result<int>.Success();

        }
        

    }
}
