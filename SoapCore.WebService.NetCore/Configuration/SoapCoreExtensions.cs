using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore.Core.Services;
using SoapCore.WebService.NetCore.Services;
using System.ServiceModel;

namespace SoapCore.WebService.NetCore.Configuration
{
    public static class SoapCoreExtensions
    {
        public static void AddSoap(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSoapCore();
            serviceCollection.TryAddSingleton<ISampleService, SampleService>();
            serviceCollection.AddMvc();
        }

        public static void ConfigureSoap(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<ISampleService>("/SoapWebService.asmx",
                    new SoapEncoderOptions(),
                    SoapSerializer.XmlSerializer,
                    caseInsensitivePath : true);
            });

        }

        public static void AddSoapMiddleware(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSoapMessageProcessor(async (message, httpcontext, next) =>
            {
                var bufferedMessage = message.CreateBufferedCopy(int.MaxValue);
                var msg = bufferedMessage.CreateMessage();
                var reader = msg.GetReaderAtBodyContents();
                var content = reader.ReadInnerXml();

                //now you can inspect and modify the content at will.
                //if you want to pass on the original message, use bufferedMessage.CreateMessage(); otherwise use one of the overloads of Message.CreateMessage() to create a new message
                var newMessage = bufferedMessage.CreateMessage();

                //pass the modified message on to the rest of the pipe.
                var responseMessage = await next(newMessage);

                //Inspect and modify the contents of returnMessage in the same way as the incoming message.
                //finish by returning the modified message.	

                return responseMessage;
            });
        }
    }
}
