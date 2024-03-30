using Newtonsoft.Json;

namespace NMD.Api;

public partial class ImpactIndicator
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "indicators";
}
