# SimpleMeasure
A quick and dirty benchmarking action filter for .NET Core!

[![Build status](https://ci.appveyor.com/api/projects/status/e6fsyn9cuia7rd9o?svg=true)](https://ci.appveyor.com/project/neekgreen/simplemeasure)
[![something](https://img.shields.io/badge/.netstandard-2.0-blue.svg)](https://img.shields.io/badge/.netstandard-1.3-blue.svg)
[![NuGet](https://img.shields.io/nuget/v/simplemeasure.svg)](https://www.nuget.org/packages/simplemeasure) 
[![NuGet](https://img.shields.io/nuget/dt/simplemeasure.svg)](https://www.nuget.org/packages/simplemeasure) 

**SimpleMeasure** includes a new header entry, `x-time-elapsed`, returning the method's execution time.
```
{
    "content-type":"application/json; charset=utf-8",
    "date": "Tue, 07 Nov 2017 06:03:55 GMT",
    "server": "Kestrel",
    "transfer-encoding": "chunked",
    ...

    "x-time-elapsed": "00:00:05.0813170"
}
```

## How do I install this package?

Use your favorite package management tool to install **SimpleMeasure**. For more information, view the package details on [NuGet](https://www.nuget.org/packages/simplemeasure).

#### Package Manager
Use this command via [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console#installing-a-package) to install the package:

```
PM> Install-Package SimpleMeasure
```

#### .NET CLI
Use this command via [.NET command-line interface (CLI)](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package) tools to install the package.

```
$ dotnet add package SimpleMeasure
```




## How do I use this SimpleMeasure?
There are two ways to configure **SimpleMeasure** with your .NET Core application:

* Manually apply the attribute to each action method
* Globally apply the attribute to all action methods


### Manually apply the attribute to each action method
You can apply the `[Benchmark]` attribute to each action method you want to calculate execution time:

```
public class ValuesController : Controller
{
    [Benchmark, HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }
}
```

### Globally apply the attribute to all action methods

You can use the `UseBenchmark` extension method in `Startup.cs` to apply the `Benchmark` attribute to all action methods.

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc().UseBenchmark();
}
```