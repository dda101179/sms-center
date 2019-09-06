using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    [XmlRoot(ElementName = "package", Namespace = "")]
    public class PackageModelDto
    {
        [XmlAttribute(AttributeName = "login")]
        public string Login { get; set; }

        [XmlAttribute(AttributeName = "password")]
        public string Password { get; set; }

        [XmlElement(ElementName = "send")]
        public SendModelDto Send { get; set; }
        public RequestPackage ToRequestPackage()
        {
            var requestPackage = new RequestPackage() {
                Credential = new Credential() { Login = Login, Password = Password },
                Messages = Send.Messages.Select(x=>(MessageOfRequest)x).ToList()
            };

            return requestPackage;
        }
    }
}
