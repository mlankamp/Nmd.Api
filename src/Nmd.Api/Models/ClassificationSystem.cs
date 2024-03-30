using Newtonsoft.Json;

namespace NMD.Api;

public partial class ClassificationSystem
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "classificationsystems";
}
