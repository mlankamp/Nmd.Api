using Newtonsoft.Json;

namespace NMD.Api;

public partial class Registration
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "registrations";
}
