using ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.CreateEmployeePersonalDetail;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks.BankDetails;
using ApwPayroll_Domain.Entities.Employees.EmergencyContacts;
using ApwPayroll_Domain.Entities.Employees.EmployeeAddresses;
using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
         var data = await _unitOfWork.Repository<EmployeePersonalDetail>().Entities.Where(x=>x.EmployeeId==request.Id).FirstOrDefaultAsync();
            if (data == null)
            {
                return Result<EmployeePersonalDetail>.NotFound();
            }
            //Bank Deatil working
            if (request.CreateEmployeePersonals.CreateEmployeeBank.Id != null && request.CreateEmployeePersonals.CreateEmployeeBank.Id != 0)
            {
                var bank = await _unitOfWork.Repository<BankDetail>().GetByIdAsync(request.CreateEmployeePersonals.CreateEmployeeBank.Id.Value);

                await _unitOfWork.Repository<BankDetail>().UpdateAsync(bank);
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
                var residentialAddress = await _unitOfWork.Repository<EmployeeAddress>().GetByIdAsync(request.CreateEmployeePersonals.ResidentialAddress.EmployeeId);
                await _unitOfWork.Repository<EmployeeAddress>().UpdateAsync(residentialAddress);
                await _unitOfWork.Save(cancellationToken);
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
                var permanentAddress = await _unitOfWork.Repository<EmployeeAddress>().GetByIdAsync(request.CreateEmployeePersonals.PermanentAddress.EmployeeId);
                await _unitOfWork.Repository<EmployeeAddress>().UpdateAsync(permanentAddress);
                await _unitOfWork.Save(cancellationToken);

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

                    CityId = request.CreateEmployeePersonals.PermanentAddress.CityId,
                    StateId = request.CreateEmployeePersonals.PermanentAddress.StateId,
                };
                await _unitOfWork.Repository<EmployeeAddress>().AddAsync(permanentAddress);
                await _unitOfWork.Save(cancellationToken);
                //    await _unitOfWork.Repository<EmployeeAddress>().AddAsync(request.CreateEmployeePersonals.PermanentAddress);

            }
            if (request.CreateEmployeePersonals.Emergency.Id != null && request.CreateEmployeePersonals.Emergency.Id != 0)
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
            _mapper.Map(request.CreateEmployeePersonals, data);

            await _unitOfWork.Repository<EmployeePersonalDetail>().UpdateAsync(data);
            await _unitOfWork.Save(cancellationToken);
            return Result<EmployeePersonalDetail>.Success(data, "Updated Successfully");
        }
    }
}
