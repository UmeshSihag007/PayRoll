//using ApwPayroll_Application.Features.DocumentTypes.Commands.CreateDocumentType;
//using ApwPayroll_Application.Features.DocumentTypes.Queries.GetAllDocumentTypes;
//using ApwPayroll_WebApi.Helper;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace ApwPayroll_WebApi.Controllers.DocumentType
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DocumentTypeController : ControllerBase
//    {
//        private readonly IMediator _mediator;
//        public DocumentTypeController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [HttpGet (Name ="DocumentType")]
//        public async Task<IActionResult> Get()
//        {
//            var data = await _mediator.Send(new GetAllDocumentTypeQuery());
//            return ResponseHelper.GenerateResponse(data);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateDocumentTypeCommand command)
//        {
//            var data = await _mediator.Send(command);
//            return ResponseHelper.GenerateResponse(data);
//        }

//    }
//}
