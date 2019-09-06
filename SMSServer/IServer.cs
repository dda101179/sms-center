using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMSServer
{
    public interface IServer
    {
        List<MessageOfResponse> SendMessage(MessageOfRequest message);
    }
}
