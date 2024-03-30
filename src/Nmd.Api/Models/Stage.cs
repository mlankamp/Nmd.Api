using Newtonsoft.Json;

namespace NMD.Api;

public partial class Stage
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "stages";
}
