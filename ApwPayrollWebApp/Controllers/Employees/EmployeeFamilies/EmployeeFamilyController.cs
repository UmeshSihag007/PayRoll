using ApwPayroll_Application.Features.Employees.Commands.CreateEmployee;
using ApwPayroll_Application.Features.Employees.EmployeeFamilies.Commands.CreateEmployeeFamily;
using ApwPayroll_Application.Features.Employees.EmployeeFamilies.Commands.UpdateEmployeeFamily;
using ApwPayroll_Application.Features.Employees.EmployeeFamilies.Queries.GetByEmployeeFamilyDetails;
using ApwPayroll_Application.Features.Employees.EmployeeFamilies.Queries.GetByEmployeeIdFamilyDetail;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.EnumHelpers;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeeFamilies
{
    public class EmployeeFamilyController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeeFamilyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateEmployeeFamily(int? id)
        {

            await InitializeViewBags();
            var model = new EmployeeCreateViewModel();
            if (id.HasValue)
            {
                var family = await _mediator.Send(new GetByEmployeeFamilyDetailQuery(id.Value));
                if(family != null)
                {
                    model.CreateEmployeeFamily = new CreateEmployeeFamilyCommand
                    {
                        DOB = family.Data.DOB,
                        Gender = family.Data.Gender,
                        Name = family.Data.Name,
                        Id = family.Data.Id
                    };
                }

                return View(model);
            }
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeFamily(EmployeeCreateViewModel model)
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            if (employeeId != 0 && employeeId != null)
            {
                model.CreateEmployeeFamily.EmployeeId = employeeId.Value;
            }

            await InitializeViewBags();
            if (ModelState.IsValid)
            {
                if (model.CreateEmployeeFamily.Id != 0 && model.CreateEmployeeFamily.Id!=null)
                {
                    var updateData = await _mediator.Send(new UpdateEmployeeFamilyCommand(model.CreateEmployeeFamily.Id.Value, model.CreateEmployeeFamily));
                   if (updateData.code == 200)
                    {
                        Notify(updateData.Messages, null, updateData.code);
                    }
                    else
                    {
                        Notify(updateData.Messages, null, updateData.code);
                    }
                }
                else
                {

            
                var data = await _mediator.Send(model.CreateEmployeeFamily);
                if (data.code == 200)
                {
                    Notify(data.Messages, null, data.code);
                }
                else
                {
                    Notify(data.Messages, null, data.code);
                }
                }

                return RedirectToAction("CreateEmployeeFamily");
            }

            return RedirectToAction("CreateEmployeeFamily");
        }


        public async Task<IActionResult> Update(int id)
        {
            var data = await _mediator.Send(new GetByEmployeeFamilyDetailQuery(id));

            if (data.code != 200)
            {
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("CreateEmployeeFamily", new { id = data.Data.Id });
        }
        private async Task InitializeViewBags()
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");

            var genderLookup = EnumHelper.GetEnumValues<GenderEnum>().ToList();

            var employeeFamilyData = await _mediator.Send(new GetByEmployeeIdFamilyDetailQuery(employeeId.Value));
        

            var employeeChildData = employeeFamilyData.Data.Where(x => x.RelationTypeId == 4).ToList();
            if (employeeChildData != null )
            {
            ViewBag.EmployeeChildData = employeeChildData;

            }
            ViewBag.GenderLookup = genderLookup;
            ViewBag.EmployeeFamilyData = employeeFamilyData.Data;
        }

    }
}
