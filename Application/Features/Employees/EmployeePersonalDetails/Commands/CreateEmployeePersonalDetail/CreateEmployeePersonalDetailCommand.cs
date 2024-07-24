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
        public int EmployeeId { get; set; }
        public CreateEmployeePersonalDetailDto CreateEmployeePersonal { get; set; }
        public CreateEmployeePersonalDetailCommand(int employeeId, CreateEmployeePersonalDetailDto createEmployeePersonal)
        {
            EmployeeId = employeeId;
            CreateEmployeePersonal = createEmployeePersonal;
        }

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
                BloodGroup = request.CreateEmployeePersonal.BloodGroup,
                DateOfWedding = request.CreateEmployeePersonal.DateOfWedding,
                DOB = request.CreateEmployeePersonal.DOB,
                Gender = request.CreateEmployeePersonal.Gender,
                MarriedStatus = request.CreateEmployeePersonal.MarriedStatus,
                PlaceOfBirth = request.CreateEmployeePersonal.PlaceOfBirth,
                Religion = request.CreateEmployeePersonal.Religion,
                IsActive = true
            };
            await _unitOfWork.Repository<EmployeePersonalDetail>().AddAsync(personalData);
            await _unitOfWork.Save(cancellationToken);
            //family
            if (request.CreateEmployeePersonal.FatherName != null || request.CreateEmployeePersonal.FatherDOB != null)
            {
                var fatherData = new EmployeeFamily
                {
                    Name = request.CreateEmployeePersonal.FatherName,
                    EmployeeId = request.EmployeeId,
                    DOB = request.CreateEmployeePersonal.DOB,
                    Gender = GenderEnum.Male,
                    RelationTypeId = 1,
                    IsActive = true,
                };
                await _unitOfWork.Repository<EmployeeFamily>().AddAsync(fatherData);
                await _unitOfWork.Save(cancellationToken);
            }
            if (request.CreateEmployeePersonal.MotherName != null || request.CreateEmployeePersonal.MotherDOB != null)
            {
                var motherData = new EmployeeFamily
                {
                    Name = request.CreateEmployeePersonal.MotherName,
                    EmployeeId = request.EmployeeId,
                    DOB = request.CreateEmployeePersonal.DOB,
                    Gender = GenderEnum.Male,
                    RelationTypeId = 2,
                    IsActive = true,
                };
                await _unitOfWork.Repository<EmployeeFamily>().AddAsync(motherData);
                await _unitOfWork.Save(cancellationToken);

            }
            if (request.CreateEmployeePersonal.SpouseName != null || request.CreateEmployeePersonal.SpouseDOB != null)
            {
                var SpouseData = new EmployeeFamily
                {
                    Name = request.CreateEmployeePersonal.SpouseName,
                    EmployeeId = request.EmployeeId,
                    DOB = request.CreateEmployeePersonal.DOB,
                    Gender = request.CreateEmployeePersonal.SpouseGender,
                    RelationTypeId = 1,
                    IsActive = true,
                };
                await _unitOfWork.Repository<EmployeeFamily>().AddAsync(SpouseData);
                await _unitOfWork.Save(cancellationToken);
            }

            // address  working 
            if (request.CreateEmployeePersonal.PermanentAddress != null)
            {
                var permanentAddress = new EmployeeAddress
                {
                    Address1 = request.CreateEmployeePersonal.PermanentAddress.Address1,
                    Address2 = request.CreateEmployeePersonal.PermanentAddress.Address2,
                    Address3 = request.CreateEmployeePersonal.PermanentAddress.Address3,
                    AddressTypeId = 1,
                    EmployeeId = request.EmployeeId,
                    Nationality = request.CreateEmployeePersonal.PermanentAddress.Nationality,
                    IsActive = true,

                    CityId = request.CreateEmployeePersonal.PermanentAddress.CityId,
                    StateId = request.CreateEmployeePersonal.PermanentAddress.StateId,
                };
                await _unitOfWork.Repository<EmployeeAddress>().AddAsync(permanentAddress);
                await _unitOfWork.Save(cancellationToken);
            }

            // address  working 
            if (request.CreateEmployeePersonal.ResidentialAddress != null)
            {
                var residentialAddress = new EmployeeAddress
                {
                    Address1 = request.CreateEmployeePersonal.ResidentialAddress.Address1,
                    Address2 = request.CreateEmployeePersonal.ResidentialAddress.Address2,
                    Address3 = request.CreateEmployeePersonal.ResidentialAddress.Address3,
                    AddressTypeId = 2,
                    EmployeeId = request.EmployeeId,
                    Nationality = request.CreateEmployeePersonal.ResidentialAddress.Nationality,
                    IsActive = true,
                    CityId = request.CreateEmployeePersonal.ResidentialAddress.CityId,
                    StateId = request.CreateEmployeePersonal.ResidentialAddress.StateId,

                };
                await _unitOfWork.Repository<EmployeeAddress>().AddAsync(residentialAddress);
                await _unitOfWork.Save(cancellationToken);
            }

            //Emergency Contact working
            if (request.CreateEmployeePersonal.Emergency != null)
            {
                var emergencyContact = new EmergencyContact
                {
                    Name = request.CreateEmployeePersonal.FatherName ?? "Testing",
                    RelationTypeId = request.CreateEmployeePersonal.Emergency.RelationTypeId,
                    Email = request.CreateEmployeePersonal.Emergency.Email,
                    MobileNumber = request.CreateEmployeePersonal.Emergency.MobileNumber,
                    WhatsAppNumber = request.CreateEmployeePersonal.Emergency.WhatsAppNumber,
                    EmployeeId = request.EmployeeId,
                };
                await _unitOfWork.Repository<EmergencyContact>().AddAsync(emergencyContact);
                await _unitOfWork.Save(cancellationToken);
            }



            // Bank Detail working

            if (request.CreateEmployeePersonal.CreateEmployeeBank != null)
            {
                var bankDetail = new BankDetail
                {
                    BankId = request.CreateEmployeePersonal.CreateEmployeeBank.BankId,
                    IFCCode = request.CreateEmployeePersonal.CreateEmployeeBank.IFCCode,
                    AccountName = request.CreateEmployeePersonal.CreateEmployeeBank.AccountName,
                    AccountBranch = request.CreateEmployeePersonal.CreateEmployeeBank.AccountBranch,
                    BanAccountId = 122,
                    EmployeeId = request.EmployeeId,


                };
                await _unitOfWork.Repository<BankDetail>().AddAsync(bankDetail);
                await _unitOfWork.Save(cancellationToken);
            }




            return Result<int>.Success();

        }

    }
}
