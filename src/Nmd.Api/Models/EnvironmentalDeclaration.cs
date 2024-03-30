using Newtonsoft.Json;

namespace NMD.Api;

public partial class EnvironmentalDeclaration
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "environmentaldeclarations";
}
