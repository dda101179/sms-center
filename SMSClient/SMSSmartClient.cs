using BL.Models;
using BL.Services;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SMSClient
{
    public class SMSSmartClient: IClient
    {
        private MessageService _messageService { get; } = new MessageService();
        public string ServerAddress { get; set; } = "http://localhost";
        public int Port { get; set; } = 7000;
        public string ApiVersion { get; set; } = "v1";
        public RequestPackage RequestPackage { get; set; } = new RequestPackage();
        public async Task<string> SendPackageAsync()
        {
            Task<string> result = null;

            var requestPackageXmlString = _buildRequestPackageXmlString();

            if (!string.IsNullOrWhiteSpace(requestPackageXmlString))
            {
                var httpContent = new StringContent(requestPackageXmlString, Encoding.UTF8, "application/xml");

                var response = await $"{ServerAddress}:{Port}/api/{ApiVersion}/Package"
                    .WithTimeout(TimeSpan.FromSeconds(60))
                    .PostAsync(httpContent);

                RequestPackage.Messages.Clear();

                result = response.Content.ReadAsStringAsync();
            }
            else
            {
                var response = _messageService.CreateResponseWithError(ErrorEnums.Invalid_Request_Package);
                result = Task.Run(()=>_messageService.ResponseToXmlString(response));
            }

            return await result;
        }
        public static ClientBuilder CreateRequestPackage()
        {
            return new ClientBuilder();
        }
        private XmlDocument _buildXml()
        {
            var xmlDocument = new XmlDocument();
            var documentNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDocument.AppendChild(documentNode);

            var packageElement = xmlDocument.CreateElement("package");
            var sendElement = xmlDocument.CreateElement("send");
            var loginAttribute = xmlDocument.CreateAttribute("login");
            var passwordAttribute = xmlDocument.CreateAttribute("password");
            var loginText = xmlDocument.CreateTextNode(RequestPackage.Credential.Login);
            var passwordText = xmlDocument.CreateTextNode(RequestPackage.Credential.Password);

            loginAttribute.AppendChild(loginText);
            passwordAttribute.AppendChild(passwordText);

            packageElement.Attributes.Append(loginAttribute);
            packageElement.Attributes.Append(passwordAttribute);
            packageElement.AppendChild(sendElement);

            foreach(var message in RequestPackage.Messages)
            {
                var messageElement = xmlDocument.CreateElement("message");
                var idAttribute = xmlDocument.CreateAttribute("id");
                var receiverAttribute = xmlDocument.CreateAttribute("receiver");
                var senderAttribute = xmlDocument.CreateAttribute("sender");

                idAttribute.AppendChild(xmlDocument.CreateTextNode(message.Id.ToString()));
                receiverAttribute.AppendChild(xmlDocument.CreateTextNode(message.Receiver.PhoneNumber));
                senderAttribute.AppendChild(xmlDocument.CreateTextNode(message.Sender.Name));

                messageElement.Attributes.Append(idAttribute);
                messageElement.Attributes.Append(receiverAttribute);
                messageElement.Attributes.Append(senderAttribute);

                messageElement.AppendChild(xmlDocument.CreateTextNode(message.Text));

                sendElement.AppendChild(messageElement);
            }

            xmlDocument.AppendChild(packageElement);

            return xmlDocument;
        }
        private string _buildXmlString(XmlDocument document)
        {
            return document.OuterXml;
        }
        private string _buildRequestPackageXmlString()
        {
            var result = "";

            try
            {
                var packageXml = _buildXml();
                result = _buildXmlString(packageXml);
            }
            catch { }

            return result;
        }
    }
}
