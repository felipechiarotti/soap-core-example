using SoapCore.Core.Models;
using System.Threading.Tasks;
using System.ServiceModel;
namespace SoapCore.Core.Services
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        Task<string> TestAsync(string s);

        [OperationContract]
        SampleResponse TestComplexModel(SampleInput inputModel);
    }
}
