# Sample Serverless Application hosted by AWS Lambda :sunglasses:

- This project shows how to run an ASP.NET Core Web API project as an AWS Lambda exposed through Amazon API Gateway.

## Give a Star! :star:

If you liked the project, please give a star ;)

## You need some of the fallowing tools :exclamation:

- Visual Studio 2019 or Visual Studio Code
- .Net Core 2.X

## Description :books:

To integrate the AWS SDK for .NET with the dependency injection system built into ASP.NET Core the NuGet package [AWSSDK.Extensions.NETCore.Setup](https://www.nuget.org/packages/AWSSDK.Extensions.NETCore.Setup/) is referenced. In the Startup.cs file the Amazon S3 client is added to the dependency injection framework. The S3ProxyController will get its S3 service client from there.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddAWSService<Amazon.S3.IAmazonS3>();
}
```

### Application Load Balancer :bulb:

To configure this project to handle requests from an Application Load Balancer instead of API Gateway change
the base class of `LambdaEntryPoint` from `Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction` to 
`Amazon.Lambda.AspNetCoreServer.ApplicationLoadBalancerFunction`.

## Startup  :heavy_check_mark:

Once you have edited your template and code you can deploy your application using the [Amazon.Lambda.Tools Global Tool](https://github.com/aws/aws-extensions-for-dotnet-cli#aws-lambda-amazonlambdatools) from the command line.

Install Amazon.Lambda.Tools Global Tools if not already installed.

```sh
    dotnet tool install -g Amazon.Lambda.Tools
```

If already installed check if new version is available.

```sh
    dotnet tool update -g Amazon.Lambda.Tools
```

Execute unit tests

```sh
    cd "LambdaShoppingListWebAi/test/LambdaShoppingListWebAi.Tests"
    dotnet test
```

Deploy application

```sh
    cd "LambdaShoppingListWebAi/src/LambdaShoppingListWebAi"
    dotnet lambda deploy-serverless
```
