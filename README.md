# DependencyInjection.InConsole
[![Build status](https://wdcdavyc.visualstudio.com/DependencyInjection.InConsole/_apis/build/status/DependencyInjection.InConsole-ASP.NET%20Core-CI)](https://wdcdavyc.visualstudio.com/DependencyInjection.InConsole/_build/latest?definitionId=-1)

DependencyInjection.InConsole allows you to use dependency injection in .net core app.

### Supported platforms
- .Net core 2.0+

### Installation

[Nuget package](https://www.nuget.org/packages/DependencyInjection.InConsole/)

### Basic use

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

For .net core 2.0 or 2.1, add the follow codes at the first line in `Main` method:

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

[example](https://github.com/Weidaicheng/DependencyInjection.InConsole/tree/master/example/)

One thing needs to remember, **DO NOT** USE `Singletons.Provider` in .net core 2.2 app if you don't use Hooks to inject, or it would throw an exception.

### Want something more

If you want something more, please check it out from [Advance Features](AdvanceFeatures.md).

### Other DI frameworks

**Autofac is supported since [1.2.3-preview](https://www.nuget.org/packages/DependencyInjection.InConsole/1.2.3-preview)🎉🎉🎉.**

You can use Autofac by the following steps.

1. Add [Autofac.Extensions.DependencyInjection](https://www.nuget.org/packages/Autofac.Extensions.DependencyInjection) package into you project.

2. Extend a class from AutofacInjector

   ```c#
   public class ExampleInjector : AutofacInjector
   {
       public override IServiceProvider Inject()
       {
           // Create the container builder.
           var builder = new ContainerBuilder();
           // register your service
           // ...
           var container = builder.Build();
       }
   }
   ```

   The codes that you need to into the `Main` method, just as same as you don't use Autofac.

   There are somethings you need to remember.

   - It's different from extending class from Injector, you can only provide one class that extends from AutofacInjector.
   - I strongly recommend that DO NOT use `builder.Populate(services);` in the Autofac register, actually you can't do that, because I don't provide one `services` for you to use😋.

### TODO

- Other DI frameworks support
  - <del>Autofac</del>
  - ...
- Property injection
- Performance optimization

### Cooperation

Please feel free to open an issue or PR, if you have any problem or new thoughts.