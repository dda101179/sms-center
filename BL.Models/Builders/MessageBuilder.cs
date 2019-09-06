using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class MessageOfRequestBuilder
    {
        private MessageOfRequest _messageOfRequest { get; set; } = new MessageOfRequest();
        public MessageOfRequestBuilder Receiver(string receiverPhoneNumber)
        {
            _messageOfRequest.Receiver.PhoneNumber = receiverPhoneNumber;

            return this;
        }
        public MessageOfRequestBuilder Sender(string senderName)
        {
            _messageOfRequest.Sender.Name = senderName;

            return this;
        }
        public MessageOfRequestBuilder Text(string text)
        {
            _messageOfRequest.Text = text;

            return this;
        }
        public MessageOfRequest Build()
        {
            return _messageOfRequest;
        }
    }
}
