using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

using NMD.Api;

using Xunit;

namespace Nmd.Tests.Unit;

public class DependencyInjectionTests
{
    [Fact]
    public void AddNmdApiClient_ShouldRegisterApiInterface()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddNmdApiClient(options =>
        {
            options.ClientId = "client-id";
            options.ClientSecret = "client-secret";
        });
        
        // Act
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Assert
        var apiClientImplementation = serviceProvider.GetService<INMDClient>();
        apiClientImplementation.Should().NotBeNull();
    }
}
