using BL.Models;
using BL.Services;
using SMSClient;
using System;

namespace Test1.ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start send some SMS");

            var server = "http://localhost";
            //server = "https://api.sms-center.business-man.space";

            var client = SMSSmartClient.CreateRequestPackage()
                .UseServer(server)
                .UsePort(7000)
                .Login("r00t")
                .Password("x777ak12")
                .AddMessage(MessageOfRequest.CreateBuilder()
                            .Receiver("+1-910-500-41-42")
                            .Sender("Author 1")
                            .Text("Hello from author 1")
                            .Build())
                .AddMessage(MessageOfRequest.CreateBuilder()
                            .Receiver("+1-910-600-41-42")
                            .Sender("Author 2")
                            .Text("Hello from author 2")
                            .Build())
                .AddMessage(MessageOfRequest.CreateBuilder()
                            .Receiver("+1-910-700-41-42")
                            .Sender("Author 3")
                            .Text("Hello from author 3")
                            .Build())
                .Build();

            var response = client.SendPackageAsync();

            var printService = new ConsolePrintService();
            printService.SetResponse(response.Result).Print();

            Console.WriteLine("Done. Press any key.");
            Console.ReadKey();
        }
    }
}
