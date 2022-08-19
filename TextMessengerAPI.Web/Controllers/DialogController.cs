using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TextMessengerAPI.Web.Features;

namespace TextMessengerAPI.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DialogController : ControllerBase
    {
        private readonly IGetIDRGDialogQueryHandler _getIdrgDialogQueryHandler;

        public DialogController(IGetIDRGDialogQueryHandler idrgDialogQueryHandler)
        {
            _getIdrgDialogQueryHandler = idrgDialogQueryHandler;
        }

        [HttpGet]
        public Guid FindByClients([FromQuery] IEnumerable<Guid> clientIds)
        {
            return _getIdrgDialogQueryHandler.Handle(new GetIDRGDialogQuery()
            {
                ClientIds = clientIds
            });
        }
    }
}
