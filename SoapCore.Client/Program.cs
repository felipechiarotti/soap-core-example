using SoapCore.Core.Models;
using SoapCore.Core.Services;
using System;
using System.ServiceModel;

namespace SoapCore.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(new Uri("http://localhost:5000/SoapWebService.asmx"));
            var channelFactory = new ChannelFactory<ISampleService>(binding, endpoint);
            var serviceClient = channelFactory.CreateChannel();
            var result = serviceClient.TestAsync("hey").Result;
            Console.WriteLine("Ping method result: {0}", result);

            var complexModel = new SampleInput
            {
                Id = 1,
                Name = "Chiarotti"
            };

            var complexResult = serviceClient.TestComplexModelAsync(complexModel);
            Console.WriteLine("ComplexModel result. Id: {0}, Name: {1}", complexResult.Id, complexResult.Name);

            Console.ReadKey();
        }
    }
}
