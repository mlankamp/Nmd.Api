using Newtonsoft.Json;

namespace NMD.Api;

public partial class Element
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "elements";
}
