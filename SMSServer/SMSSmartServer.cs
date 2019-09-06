using BL.Models;
using SMSServer.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSServer
{
    public class SMSSmartServer: IServer
    {
        private int _maxSymbolsInOneMessage { get; } = 70;
        private IDevice _device { get; } = new SmartDevice();
        public List<MessageOfResponse> SendMessage(MessageOfRequest message)
        {
            var result = new List<MessageOfResponse>();

            var textForSend = message.Text.ToCharArray();
            var iteration = 0;

            Func<string> getPartOfMessage = () => new String(textForSend.Skip(_maxSymbolsInOneMessage * iteration++).Take(_maxSymbolsInOneMessage).ToArray()).Trim();
            var messagePart = getPartOfMessage();

            while (!String.IsNullOrWhiteSpace(messagePart))
            {
                message.Text = messagePart;
                var resultResponse = _device.SendMessage(message);
                MessageOfResponse response;

                if (resultResponse == ErrorEnums.No_Errors)
                {
                    // good result
                    response = new MessageOfResponse()
                    {
                        Id = message.Id.ToString(),
                        ServerId = Guid.NewGuid().ToString(),
                        Text = message.Text,
                    };
                } else
                {
                    // bad result
                    response = new MessageOfResponse()
                    {
                        Id = message.Id.ToString(),
                        Error = resultResponse.ToString(),
                    };
                }
                result.Add(response);

                messagePart = getPartOfMessage();
            }

            return result;
        }
    }
}
