using Newtonsoft.Json;

namespace NMD.Api;

public partial class Component
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "components";
}
