using ApwPayroll_Application.Features.Banks.Commands.CreateBankCommands;
using ApwPayroll_Application.Features.Banks.Commands.DeleteBankCommands;
using ApwPayroll_Application.Features.Banks.Commands.UpdateBankCommands;
using ApwPayroll_Application.Features.Banks.Queries.GetAllBanks;
using ApwPayroll_Application.Features.Branches.Queries.GetBranchLookUpQuery;
using ApwPayroll_Domain.common.Enums.AccountType;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.EnumHelpers;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Masters.Banks;

public class BankController : BaseController
{
    private readonly IMediator _mediator;

    public BankController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> BankView(int? id)
    {
        await InitializeViewBag();
        var model = new MasterModel();
        var accountType = EnumHelper.GetEnumValues<AccountTypeEnum>().ToList();
        ViewBag.AccountType = accountType;

        var branchData = await _mediator.Send(new GetBranchLookUpQuery());
        ViewBag.BranchList = branchData.Data;

        if (id.HasValue && id != 0)
        {
            var bankData = await _mediator.Send(new GetAllBankQuery());
            var bank = bankData.Data.FirstOrDefault(x => x.Id == id.Value);
            if (bank != null)
            {
                model.createBank = new CreateBankCommand
                {
                    Id = bank.Id,
                    Name = bank.Name,
                    EmployeeId = bank.EmployeeId,
                    IsBankAccountVerified = bank.IsBankAccountVerified,
                    AccountNumber = bank.AccountNumber,
                    IFCCode = bank.IFCCode,
                    AccountName = bank.AccountName,
                    AccountType = bank.AccountType,
                    BranchId = bank.BranchId,
                };
            }
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBank(MasterModel commad)
    {
        if (commad.createBank.Id == 0 || commad.createBank.Id == null)
        {
            var data = await _mediator.Send(commad.createBank);
            if (data.code==200)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }

        }
        else
        {
            var data = await _mediator.Send(new UpdateBankCommand((int)commad.createBank.Id, commad.createBank));
            if (data.code==200)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }
        }
        return RedirectToAction("BankView");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var data = await _mediator.Send(new DeleteBankCommand(id));
        if (data.succeeded)
        {
            Notify(data.Messages, null, data.code);
        }
        else
        {
            Notify(data.Messages, null, data.code);
        }
        return RedirectToAction("BankView");
    }

    private async Task InitializeViewBag()
    {
        var locationResult = await _mediator.Send(new GetAllBankQuery());

        if (locationResult != null && locationResult.Data != null)
        {
            ViewBag.BankList = locationResult?.Data;
        }
    }
}



