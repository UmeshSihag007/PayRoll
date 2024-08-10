using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.DeleteEmployeeReferences;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;
using ApwPayroll_Domain.Entities.ReferralDetails;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Holidays.Commands.DeleteHolidays;

public class DeleteHolidayCommand : IRequest<Result<int>>
{
    public int Id { get; set; }
    public DeleteHolidayCommand(int id = 0)
    {
        Id = id;
    }
}
internal class DeleteHolidayCommandHandler : IRequestHandler<DeleteHolidayCommand,Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHolidayCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteHolidayCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Holiday>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.BadRequest();
        }

        var holidayTypeRules = await _unitOfWork.Repository<HolidayTypeRule>().Entities
          .Where(rule => rule.HolidayId == request.Id)
          .ToListAsync(cancellationToken);
        if (holidayTypeRules.Any())
        {
            foreach (var rule in holidayTypeRules)
            {
                await _unitOfWork.Repository<HolidayTypeRule>().DeleteAsync(rule);
            }
        }

        await _unitOfWork.Repository<Holiday>().DeleteAsync(data);


        await _unitOfWork.Save(cancellationToken);

        return Result<int>.BadRequest("Deleted Successfully");
    }
}
