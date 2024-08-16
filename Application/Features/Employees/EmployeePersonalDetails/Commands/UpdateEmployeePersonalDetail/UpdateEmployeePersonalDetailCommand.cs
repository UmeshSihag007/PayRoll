using ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.CreateEmployeePersonalDetail;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Domain.Entities.Banks.BankDetails;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmergencyContacts;
using ApwPayroll_Domain.Entities.Employees.EmployeeAddresses;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
 

namespace ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.UpdateEmployeePersonalDetail
{
    public class UpdateEmployeePersonalDetailCommand : IRequest<Result<EmployeePersonalDetail>>
    {
        public UpdateEmployeePersonalDetailCommand(int id, CreateEmployeePersonalDetailDto createEmployeePersonals)
        {
            Id = id;
            CreateEmployeePersonals = createEmployeePersonals;
        }

        public int Id { get; set; }
        public CreateEmployeePersonalDetailDto CreateEmployeePersonals { get; set; }
    }
    internal class UpdateEmployeePersonalDetailCommandHandler : IRequestHandler<UpdateEmployeePersonalDetailCommand, Result<EmployeePersonalDetail>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeePersonalDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<EmployeePersonalDetail>> Handle(UpdateEmployeePersonalDetailCommand request, CancellationToken cancellationToken)
        {
 
            var data = await _unitOfWork.Repository<EmployeePersonalDetail>().Entities.Where(x => x.EmployeeId == request.Id && x.IsDeleted == false).FirstOrDefaultAsync();
 
            if (data == null)
            {
                return Result<EmployeePersonalDetail>.NotFound();
            }
            //Bank Details working
            if (request.CreateEmployeePersonals.CreateEmployeeBank.Id != null && request.CreateEmployeePersonals.CreateEmployeeBank.Id != 0)
            {
                var bank = await _unitOfWork.Repository<BankDetail>().GetByIdAsync(request.CreateEmployeePersonals.CreateEmployeeBank.Id.Value);
                var mapData = _mapper.Map(request.CreateEmployeePersonals.CreateEmployeeBank, bank);
                mapData.EmployeeId = request.Id;
                await _unitOfWork.Repository<BankDetail>().UpdateAsync(mapData);
                await _unitOfWork.Save(cancellationToken);
            }
            else
            {
                var bankDetail = new BankDetail
                {
                    BankId = request.CreateEmployeePersonals.CreateEmployeeBank.BankId,
                    IFCCode = request.CreateEmployeePersonals.CreateEmployeeBank.IFCCode,
                    AccountName = request.CreateEmployeePersonals.CreateEmployeeBank.AccountName,
                    AccountBranch = request.CreateEmployeePersonals.CreateEmployeeBank.AccountBranch,
                    BanAccountId = request.CreateEmployeePersonals.CreateEmployeeBank.BanAccountId,
                    AccountType = request.CreateEmployeePersonals.CreateEmployeeBank.AccountType,
                    EmployeeId = data.EmployeeId,


                };
                await _unitOfWork.Repository<BankDetail>().AddAsync(bankDetail);
                await _unitOfWork.Save(cancellationToken);
                // await _unitOfWork.Repository<BankDetail>().AddAsync(request.CreateEmployeePersonals.CreateEmployeeBank);
            }

            //Address Working
            if (request.CreateEmployeePersonals.ResidentialAddress.EmployeeId != null && request.CreateEmployeePersonals.ResidentialAddress.EmployeeId != 0)
            {
                var residentialAddress = await _unitOfWork.Repository<EmployeeAddress>().Entities.Where(x => x.EmployeeId == request.CreateEmployeePersonals.PermanentAddress.EmployeeId  && x.AddressTypeId==2).FirstOrDefaultAsync();
                if (residentialAddress != null)
                {
                    var mapData = _mapper.Map(request.CreateEmployeePersonals.ResidentialAddress, residentialAddress);
                    mapData.EmployeeId = request.Id;
                    mapData.AddressTypeId = 2;
                    mapData.LocationId = request.CreateEmployeePersonals.ResidentialAddress.LocationId;
                    await _unitOfWork.Repository<EmployeeAddress>().UpdateAsync(mapData);
                await _unitOfWork.Save(cancellationToken);
 
                }
            }
 
            else
            {
                var residentialAddress = new EmployeeAddress
                {
                    Address1 = request.CreateEmployeePersonals.ResidentialAddress.Address1,
                    Address2 = request.CreateEmployeePersonals.ResidentialAddress.Address2,
                    Address3 = request.CreateEmployeePersonals.ResidentialAddress.Address3,
                    AddressTypeId = 2,
                    EmployeeId = data.EmployeeId,
                    Nationality = request.CreateEmployeePersonals.ResidentialAddress.Nationality,
                    IsActive = true,
                    CityId = request.CreateEmployeePersonals.ResidentialAddress.CityId,
                    StateId = request.CreateEmployeePersonals.ResidentialAddress.StateId,

                };
                await _unitOfWork.Repository<EmployeeAddress>().AddAsync(residentialAddress);
                await _unitOfWork.Save(cancellationToken);
            }
            if (request.CreateEmployeePersonals.PermanentAddress.EmployeeId != null && request.CreateEmployeePersonals.PermanentAddress.EmployeeId != 0)
            {
                var permanentAddress = await _unitOfWork.Repository<EmployeeAddress>().Entities.Where(x=>x.EmployeeId== request.CreateEmployeePersonals.PermanentAddress.EmployeeId && x.AddressTypeId==1).FirstOrDefaultAsync();
                if (permanentAddress != null)
                {
                    var mapData = _mapper.Map(request.CreateEmployeePersonals.PermanentAddress, permanentAddress);
                    mapData.EmployeeId = request.Id;
                    mapData.AddressTypeId = 1;
                    mapData.LocationId = request.CreateEmployeePersonals.PermanentAddress.LocationId;
                    await _unitOfWork.Repository<EmployeeAddress>().UpdateAsync(mapData);
                    await _unitOfWork.Save(cancellationToken);           
                }

            }
            else
            {
                var permanentAddress = new EmployeeAddress
                {
                    Address1 = request.CreateEmployeePersonals.PermanentAddress.Address1,
                    Address2 = request.CreateEmployeePersonals.PermanentAddress.Address2,
                    Address3 = request.CreateEmployeePersonals.PermanentAddress.Address3,
                    AddressTypeId = 1,
                    EmployeeId = data.EmployeeId,
                    Nationality = request.CreateEmployeePersonals.PermanentAddress.Nationality,
                    IsActive = true,

                    CityId = request.CreateEmployeePersonals.PermanentAddress.LocationId,
                    StateId = request.CreateEmployeePersonals.PermanentAddress.StateId,
                };
                await _unitOfWork.Repository<EmployeeAddress>().AddAsync(permanentAddress);
                await _unitOfWork.Save(cancellationToken);
                //    await _unitOfWork.Repository<EmployeeAddress>().AddAsync(request.CreateEmployeePersonals.PermanentAddress);
            }

            //Emergency Contact Working

            if (request.CreateEmployeePersonals.Emergency.Id != null && request.CreateEmployeePersonals.Emergency.Id!=0)
 
            {
                var emergency = await _unitOfWork.Repository<EmergencyContact>().GetByIdAsync(request.CreateEmployeePersonals.Emergency.Id);
                await _unitOfWork.Repository<EmergencyContact>().UpdateAsync(emergency);
                await _unitOfWork.Save(cancellationToken);
            }
            else
            {
                await _unitOfWork.Repository<EmergencyContact>().AddAsync(request.CreateEmployeePersonals.Emergency);
                await _unitOfWork.Save(cancellationToken);
            }

 
            ///  Family Detail

          //father details
            if (request.CreateEmployeePersonals.FatherName != null || request.CreateEmployeePersonals.FatherDOB != null)
            {
                var fatherData = new EmployeeFamily
                {
                    Name = request.CreateEmployeePersonals.FatherName,
                    EmployeeId = request.Id ,
                    DOB = request.CreateEmployeePersonals.DOB,
                    Gender = GenderEnum.Male,
                    RelationTypeId = 1,
                    IsActive = true,
                };
                await _unitOfWork.Repository<EmployeeFamily>().AddAsync(fatherData);
                await _unitOfWork.Save(cancellationToken);
            }

            //  mother details 
            if (request.CreateEmployeePersonals.MotherName != null || request.CreateEmployeePersonals.MotherDOB != null)
            {
                var motherData = new EmployeeFamily
                {
                    Name = request.CreateEmployeePersonals.MotherName,
                    EmployeeId = request.Id,
                    DOB = request.CreateEmployeePersonals.DOB,
                    Gender = GenderEnum.Male,
                    RelationTypeId = 2,
                    IsActive = true,
                };
                await _unitOfWork.Repository<EmployeeFamily>().AddAsync(motherData);
                await _unitOfWork.Save(cancellationToken);

            }

            //spouse details
            if (request.CreateEmployeePersonals.SpouseName != null || request.CreateEmployeePersonals.SpouseDOB != null)
            {
                var SpouseData = new EmployeeFamily
                {
                    Name = request.CreateEmployeePersonals.SpouseName,
                    EmployeeId = request.Id,
                    DOB = request.CreateEmployeePersonals.DOB,
                    Gender = request.CreateEmployeePersonals.SpouseGender,
                    RelationTypeId = 4,
                    IsActive = true,
                };
                await _unitOfWork.Repository<EmployeeFamily>().AddAsync(SpouseData);
                await _unitOfWork.Save(cancellationToken);
            }

            var employeePersonalDetail = new EmployeePersonalDetail
            {
                Id=data.Id,
                EmployeeId = request.Id,
                DOB = request.CreateEmployeePersonals.DOB,
                Gender = request.CreateEmployeePersonals. Gender,
                PlaceOfBirth = request.CreateEmployeePersonals.PlaceOfBirth,
                Religion = request.CreateEmployeePersonals.Religion  ,
                BloodGroup = request.CreateEmployeePersonals.BloodGroup  ,
                MarriedStatus = request.CreateEmployeePersonals.MarriedStatus  ,
                DateOfWedding = request.CreateEmployeePersonals.DateOfWedding  ,
                IsActive = true
            };

              await _unitOfWork.Repository<EmployeePersonalDetail>().UpdateAsync(employeePersonalDetail);
 
            await _unitOfWork.Save(cancellationToken);
            return Result<EmployeePersonalDetail>.Success(data, "Updated Successfully");
        }
    }
}
