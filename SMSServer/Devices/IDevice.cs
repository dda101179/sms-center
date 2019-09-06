using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMSServer.Devices
{
    public interface IDevice
    {
        ErrorEnums SendMessage(MessageOfRequest message);
    }
}
