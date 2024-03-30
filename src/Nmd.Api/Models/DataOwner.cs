using Newtonsoft.Json;

namespace NMD.Api;

public partial class DataOwner
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "owners";
}
