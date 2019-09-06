using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    public class SendModelDto
    {
        [XmlElement(ElementName = "message")]
        public MessageModelDto[] Messages { get; set; }
    }
}
