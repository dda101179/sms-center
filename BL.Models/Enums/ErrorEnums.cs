using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public enum ErrorEnums
    {
        No_Errors,
        Unknown,
        Invalid_Request_Package,
        Invalid_Login_Or_Password,
        Sender_Is_Not_Ready,
        Hardware_Is_Not_Connected
    }
}
