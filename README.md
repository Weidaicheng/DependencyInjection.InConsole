# DependencyInjection.InConsole
[![Build status](https://wdcdavyc.visualstudio.com/DependencyInjection.InConsole/_apis/build/status/DependencyInjection.InConsole-ASP.NET%20Core-CI)](https://wdcdavyc.visualstudio.com/DependencyInjection.InConsole/_build/latest?definitionId=-1)

DependencyInjection.InConsole allows you to use dependency injection in .net core app.

#### Supported platforms
- .Net core 2.0+

#### Installation

[Nuget package](https://www.nuget.org/packages/DependencyInjection.InConsole/)

#### Basic use

```c#
// extends a class from Injector, and override it's Inject method to do inject
public class ExampleInjector : Injector
{
    public override void Inject()
    {
        services.AddTransient<Interface, Implication>();
    }
}
```

For .net core 1.0 or 1.1, add the follow codes at the first line in `Main` method:

```c#
var provider = Startup.ConfigureServices();
// or, if you don't need a provider
Startup.ConfigureServices();
```

But for .net core 2.2, you can choose using Hooks, so there's nothing need to be added into `Main` method, but if you need to use `provider`, you can get one by this:

```c#
var provider = Singletons.Provider;
```

You need to add an environment variable, name as `DOTNET_STARTUP_HOOKS`, and key as the absolute path of `DependencyInjection.InConsole.dll`, for example `C:\DependencyInjection.InConsole.dll`.

That's it, now you can use the type that you just injected.

And this injected `IConfiguration` from `appsettings.json` by default, so you can use it without extra injection:

```c#
var configuration = provider.GetRequiredService<IConfiguration>();
Console.WriteLine(configuration["foo"]);
```

You can check the example code in 

[example](https://github.com/Weidaicheng/DependencyInjection.InConsole/tree/master/example/DependencyInjection.InConsole.Example)

One thing needs to remember, DO NOT USE `Singletons.Provider` in .net core 2.2 app if you don't use Hooks to inject, or it would throw an exception.

#### Cooperation

Please feel free to open an issue or pull request, if you have any problem or new thoughts.