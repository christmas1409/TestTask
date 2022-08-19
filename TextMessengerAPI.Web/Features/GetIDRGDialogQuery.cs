using System;
using System.Collections.Generic;

namespace TextMessengerAPI.Web.Features
{
    public class GetIDRGDialogQuery
    {
        public IEnumerable<Guid> ClientIds { get; set; }
    }
}
