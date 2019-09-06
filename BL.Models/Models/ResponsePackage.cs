using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class ResponsePackage
    {
        public List<MessageOfResponse> Messages { get; set; } = new List<MessageOfResponse>();
        public ErrorEnums ErrorCode { get; set; } = ErrorEnums.No_Errors;
        public ResponsePackage SetErrorInvalidRequestPackage()
        {
            ErrorCode = ErrorEnums.Invalid_Request_Package;

            return this;
        }
        public bool HasError { get => ErrorCode != ErrorEnums.No_Errors; }
    }
}
