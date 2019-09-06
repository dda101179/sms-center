using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    public class MessageModelDto
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "receiver")]
        public string Receiver { get; set; }

        [XmlAttribute(AttributeName = "sender")]
        public string Sender { get; set; }

        [XmlText]
        public string Text { get; set; }

        public static implicit operator MessageOfRequest(MessageModelDto message)
        {
            var messageOfRequest = new MessageOfRequest()
            {
                Receiver = new Receiver() { PhoneNumber = message.Receiver },
                Sender = new Sender() { Name = message.Sender },
                Text = message.Text,
            };

            return messageOfRequest;
        }
    }
}
