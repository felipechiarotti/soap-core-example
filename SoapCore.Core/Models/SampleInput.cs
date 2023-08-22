using System.Runtime.Serialization;

namespace SoapCore.Core.Models
{
    [DataContract]
    public class SampleInput
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
