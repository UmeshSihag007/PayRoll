using ApwPayroll_Application.Features.Branches.Commands.CreateBranchCommands;
using ApwPayroll_Application.Features.Branches.Commands.DeleteBranchCommands;
using ApwPayroll_Application.Features.Branches.Commands.UpdateBranchCommands;
using ApwPayroll_Application.Features.Branches.Commands.UpdateBranchStatusCommands;
using ApwPayroll_Application.Features.Branches.Queries.GetAllBranches;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Masters.Branches
{
    public class BranchController : BaseController
    {
        private readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> BranchView(int? id)
        {
            await InitializeViewBag();
            var model = new MasterModel();
            if (id.HasValue && id != 0)
            {
                var branchData = await _mediator.Send(new GetAllBranchQuery());
                var branch = branchData.Data.FirstOrDefault(x => x.Id == id.Value);
                if (branch != null)
                {
                    model.createBranch = new CreateBranchCommand
                    {
                        Id = branch.Id,
                        Name = branch.Name,
                        IsActive = branch.IsActive,
                    };
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(MasterModel model)
        {
            if (model.createBranch.Id == 0 || model.createBranch.Id == null)
            {
                var data = await _mediator.Send(model.createBranch);
                Notify(data.Messages, null, data.code);
            }
            else
            {
                var data = await _mediator.Send(new UpdateBranchCommand((int)model.createBranch.Id, model.createBranch));
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("BranchView");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, bool isActive)
        {
            var data = await _mediator.Send(new UpdateBranchStatusCommand(id, isActive));
            Notify(data.Messages, null, data.code);
            return RedirectToAction("BranchView");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteBranchCommand(id));
            Notify(data.Messages, null, data.code);
            return RedirectToAction("BranchView");
        }

        private async Task InitializeViewBag()
        {
            var branchList = await _mediator.Send(new GetAllBranchQuery());
            ViewBag.Branch = branchList?.Data?.ToList();
        }
    }
}
