using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class MessageOfResponse
    {
        public string Id { get; set; }
        public string ServerId { get; set; }
        public string Text { get; set; }
        public string Error { get; set; }
        public bool HasError { get => !string.IsNullOrWhiteSpace(Error); }
    }
}
