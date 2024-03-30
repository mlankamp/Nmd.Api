using Newtonsoft.Json;

namespace NMD.Api;

public partial class FieldOfApplication
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "fieldofapplications";
}
