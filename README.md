# NMD Api
![](https://github.com/mlankamp/Nmd.Api/workflows/Run%20automated%20tests/badge.svg)

This project allows you to easily add the [Nationale Milieudatabase](https://api.documentatie.milieudatabase.nl/) to your application.

## Support
If you have encounter any issues while using this library or have any feature requests, feel free to open an issue on GitHub.


## Contributions
Have you spotted a bug or want to add a missing feature? All pull requests are welcome! Please provide a description of the bug or feature you have fixed/added. Make sure to target the latest development branch. 

## Supported .NET versions
This library is built using net6.0. This means that the package supports the following .NET implementations:

|.NET implementation|Version support|
|-|-|
|.NET and .NET Core|6.0, 7.0, 8.0|

## Installing the library
The easiest way to install the NPM Api library is to use the Nuget Package.

```
Install-Package Nmd.Api
```

## Creating a API client
The recommended way to instantiate the API client, is to use the built in dependency injection extension method:

```csharp
builder.Services.AddNmdApiClient(options => {
  options.ClientId = builder.Configuration["NMD:ClientId"];
  options.ClientSecret = builder.Configuration["NMD:ClientSecret"];
});
```

Alternatively, you can create the API client manually using the constructor.
```csharp
var config = new NMDConfiguration() {
  ClientId = "your-client-id",
  ClientSecret = "your-client-secret"
};
var client = new NMDClient(new HttpClient(), config);
```
