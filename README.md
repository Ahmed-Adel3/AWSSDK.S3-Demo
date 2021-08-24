
# ➽To use this repo :
☞You just to put your ows __AWS Access Key__ and __AWS Secret Access Key__ in the main method in the console app and try.
_________________________________________________________________
# ➽What is the AWS SDK for .NET?
☞The AWS SDK for .NET makes it easier to build .NET applications that tap into cost-effective, scalable, and reliable AWS services such as Amazon Simple Storage Service (`Amazon S3`) and Amazon Elastic Compute Cloud (`Amazon EC2`). The SDK simplifies the use of AWS services by providing a set of libraries that are consistent and familiar for .NET developers.

![AWS SDKs](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/0gezp1dj5xdijne3b6n6.png)

Let's start in this article with the first SDK which is `AWSSDK.S3` ...

`AWSSDK.S3` is a SDK that helps .Net Developers to use Access Amazon Simple Storage Service (`Amazon S3`) in their applications  to create buckets and store objects.

`Amazon S3` is storage for the Internet. It is designed to make web-scale computing easier.

`Amazon S3` has a simple web services interface that you can use to store and retrieve any amount of data, at any time, from anywhere on the web. It gives any developer access to the same highly scalable, reliable, fast, and inexpensive data storage infrastructure that Amazon uses to run its own global network of web sites, to read more about it [go here](https://docs.aws.amazon.com/AmazonS3/latest/userguide/Welcome.html).
_________________________________________________________________
# ➽Installing AWSSDK.S3 :
☞`AWSSDK.S3` is installed mainly from Nuget, which is a package management system for the .NET platform. With NuGet, you can install the AWSSDK packages, as well as several other extensions, to your project, and here is [Nuget Website] (https://www.nuget.org/)

There is 3 ways to install `AWSSDK.S3` (or any other Nuget Package in General)

✎ __1- Using NuGet from the Command prompt or terminal:__
➤ Go to the [AWSSDK packages on NuGet](https://www.nuget.org/profiles/awsdotnet)
 and determine which packages you need in your project; today we will install , [AWSSDK.S3](https://www.nuget.org/packages/AWSSDK.S3/).
➤ Copy the .NET CLI command from that package's webpage, as shown in the following example.

```csharp
dotnet add package AWSSDK.S3 --version 3.3.110.19
```

➤ In your project's directory, run that .NET CLI command. NuGet also installs any dependencies, such as __AWSSDK.Core__ (which is the main dependency for all AWS SDKs for .Net ).

✎ __2- Using NuGet Package Manager in Visual Studio:__
➤ In Solution Explorer, right-click your project, and then choose Manage NuGet Packages from the context menu.

➤ In the left pane of the NuGet Package Manager, choose Browse. You can then use the search box to search for the package you want to install.

➤ The following figure shows installation of the `AWSSDK.S3` package.

![Nuget Package Manager](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/n4lkyb66z16pt22piytz.png)

✎ __3- Using NuGet from the Package Manager Console:__
➤ In Visual Studio, choose Tools, NuGet Package Manager, Package Manager Console.

➤ You can install the AWSSDK packages you want from the Package Manager Console by using the Install-Package command. For example, to install AWSSDK.S3, use the following command.
```csharp
PM> Install-Package AWSSDK.S3
```
➤ If you need to install an earlier version of a package, use the -Version option and specify the package version you want, as shown in the following example.
```csharp
PM> Install-Package AWSSDK.S3 -Version 3.3.106.6
```

