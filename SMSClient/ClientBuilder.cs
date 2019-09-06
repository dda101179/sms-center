using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMSClient
{
    public class ClientBuilder
    {
        private SMSSmartClient _client { get; set; } = new SMSSmartClient();
        public ClientBuilder UseServer(string serverAddress)
        {
            _client.ServerAddress = serverAddress;

            return this;
        }
        public ClientBuilder UsePort(int port)
        {
            _client.Port = port;

            return this;
        }
        public ClientBuilder Login(string login)
        {
            _client.RequestPackage.Credential.Login = login;

            return this;
        }
        public ClientBuilder Password(string password)
        {
            _client.RequestPackage.Credential.Password = password;

            return this;
        }
        public ClientBuilder AddMessage(MessageOfRequest message)
        {
            _client.RequestPackage.Messages.Add(message);

            return this;
        }
        public IClient Build()
        {
            return _client;
        }
    }
}
