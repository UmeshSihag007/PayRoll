﻿using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Shared;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Designations.Commands.DeleteDesignation;

public class DeleteDesignationCommand : IRequest<Result<int>>
{
    public DeleteDesignationCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
internal class DeleteDesignationCommandHandler : IRequestHandler<DeleteDesignationCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDesignationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteDesignationCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Designation>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.NotFound();
        }
        await _unitOfWork.Repository<Designation>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.BadRequest("Deleted Successfully");
    }
}
