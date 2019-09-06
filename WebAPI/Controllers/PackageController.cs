using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using BL.Models;
using BL.Services;
using Microsoft.AspNetCore.Mvc;
using SMSServer;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private MessageService _messageService { get; } = new MessageService();

        [HttpPost]
        public string Post([FromBody] PackageModelDto packageDto)
        {
            var result = "";
            ResponsePackage response;

            if (ModelState.IsValid)
                response = _messageService.SendPackage(packageDto.ToRequestPackage());
            else
                response = _messageService.CreateResponseWithError(ErrorEnums.Invalid_Request_Package);

            result = _messageService.ResponseToXmlString(response);

            return result;
        }
    }
}
