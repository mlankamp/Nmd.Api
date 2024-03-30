using NMD.Api;
using NMD.Api.Options;

using Polly;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNmdApiClient(
        this IServiceCollection services,
        Action<NMDConfiguration> optionsDelegate,
        IAsyncPolicy<HttpResponseMessage>? retryPolicy = null)
    {
        var config = new NMDConfiguration();
        optionsDelegate.Invoke(config);

        RegisterNmdApiClient<INMDClient, NMDClient>(services, httpClient => new NMDClient(httpClient, config), retryPolicy);

        return services;
    }

    static void RegisterNmdApiClient<TInterface, TImplementation>(
            IServiceCollection services,
            Func<HttpClient, TImplementation> factory,
            IAsyncPolicy<HttpResponseMessage>? retryPolicy = null)
            where TInterface : class
            where TImplementation : class, TInterface
    {
        var clientBuilder = services.AddHttpClient<TInterface, TImplementation>(factory);
        if (retryPolicy != null)
        {
            clientBuilder.AddPolicyHandler(retryPolicy);
        }
    }
}
