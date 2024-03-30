using Newtonsoft.Json;

namespace NMD.Api;

public partial class Unit
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "units";
}
