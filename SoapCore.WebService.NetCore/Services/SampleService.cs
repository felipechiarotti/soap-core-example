using SoapCore.Core.Models;
using SoapCore.Core.Services;
using System.Threading.Tasks;

namespace SoapCore.WebService.NetCore.Services
{
    public class SampleService : ISampleService
    {
        public Task<string> TestAsync(string s)
        {
            return Task.Run(() => s);
        }

        public SampleResponse TestComplexModel(SampleInput inputModel)
        {
            return new SampleResponse()
            {
                Id = inputModel.Id,
                Name = inputModel.Name
            };
        }
    }
}
