using System.Runtime.Serialization;

namespace SoapCore.Core.Models
{
    [DataContract]
    public class SampleResponse
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
