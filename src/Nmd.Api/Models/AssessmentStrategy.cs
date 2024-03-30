using Newtonsoft.Json;

namespace NMD.Api;

public partial class AssessmentStrategy
{
    [JsonProperty("partitionKey")]
    public string PartitionKey => "assessmentstrategies";
}
