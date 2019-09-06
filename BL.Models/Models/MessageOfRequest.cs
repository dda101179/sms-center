using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class MessageOfRequest
    {
        private static int _id = 1;
        public MessageOfRequest()
        {
            Id = MessageOfRequest._id++;
        }
        public Receiver Receiver { get; set; } = new Receiver();
        public Sender Sender { get; set; } = new Sender();
        public string Text { get; set; }
        public int Id { get; set; }
        public static MessageOfRequestBuilder CreateBuilder()
        {
            return new MessageOfRequestBuilder();
        }
    }
}
