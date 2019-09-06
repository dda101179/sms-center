using BL.Models;
using SMSServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services
{
    public class MessageService
    {
        private IdentityService _identityService { get; } = new IdentityService();
        private IServer _server { get; } = new SMSSmartServer();
        public ResponsePackage SendPackage(RequestPackage package)
        {
            var response = new ResponsePackage();

            var profile = _identityService.Login(package.Credential);

            if (profile != null)
            {
                foreach (var message in package.Messages)
                {
                    var responseFromServer = _server.SendMessage(message);
                    response.Messages.AddRange(responseFromServer);
                }
            } else
            {
                response = CreateResponseWithError(ErrorEnums.Invalid_Login_Or_Password);
            }

            return response;
        }
        public string ResponseToXmlString(ResponsePackage response)
        {
            var result = "";

            if (response.HasError)
                result = $"<package>\n<error>\nError{(int)response.ErrorCode}. {GetTextErrorByCodeError(response.ErrorCode)}\n</error>\n</package>\n";
            else
            {
                var sb = new StringBuilder();
                foreach (var message in response.Messages)
                    if (message.HasError)
                    {
                        ErrorEnums errorCodeInMessage = (ErrorEnums)Enum.Parse(typeof(ErrorEnums), message.Error);
                        sb.Append($"<message id='{message.Id}'><error>Error{(int)errorCodeInMessage}. {GetTextErrorByCodeError(errorCodeInMessage)}</error></message>\n");
                    }
                    else
                        sb.Append($"<message id='{message.Id}' server_id='{message.ServerId}'>{message.Text}</message>\n");

                result = $"<package>\n<send>\n{sb.ToString()}</send>\n</package>\n";
            }

            return result;
        }
        public string GetTextErrorByCodeError(ErrorEnums error)
        {
            var textErrorMessage = "Not error describe";

            switch (error)
            {
                case ErrorEnums.Invalid_Request_Package:
                    textErrorMessage = "Invalid Data Request Package";
                    break;
                case ErrorEnums.Invalid_Login_Or_Password:
                    textErrorMessage = "Invalid Credential (login or password)";
                    break;
                case ErrorEnums.Hardware_Is_Not_Connected:
                    textErrorMessage = "Hardware is off or not connected";
                    break;
                case ErrorEnums.Sender_Is_Not_Ready:
                    textErrorMessage = "Sender is not ready to receive message";
                    break;
            }

            return textErrorMessage;
        }
        public ResponsePackage CreateResponseWithError(ErrorEnums error)
        {
            var result = new ResponsePackage()
            {
                ErrorCode = error,
            };

            return result;
        }
    }
}
