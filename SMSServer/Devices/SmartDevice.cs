using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMSServer.Devices
{
    public class SmartDevice: IDevice
    {
        public ErrorEnums SendMessage(MessageOfRequest message)
        {
            var result = ErrorEnums.No_Errors;

            // Device can send any SMS but cannot send SMS with Id=2 (or Id%3=0)
            if (message.Id == 2) result = ErrorEnums.Hardware_Is_Not_Connected;
            if (message.Id % 3 == 0) result = ErrorEnums.Sender_Is_Not_Ready;

            return result;
        }
    }
}
