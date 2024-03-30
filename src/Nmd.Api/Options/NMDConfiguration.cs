#nullable disable
namespace NMD.Api.Options;

public class NMDConfiguration
{
    public string GrantType { get; set; } = "client_credentials";

    public string ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string Scope { get; set; } = "nmd-database:read";

    public string AuthUrl { get; set; } = "https://idp.nmd.fluxility.dev/o/token/";

    public string BaseUrl { get; set; } = "https://database.milieudatabase.nl";
}
