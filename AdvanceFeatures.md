#### Sections

- [Injection with parameters](#Injection with parameters)



### Injection with parameters

Since [1.3.2-preview](https://www.nuget.org/packages/DependencyInjection.InConsole/1.3.2-preview), you can inject with parameters, instead of using a non parameter injection method.

One thing needs to know, .net core 2.2 hooks is **NOT supported** for this feature, because the parameters can not be passed through hooks.

For **basic injection**, follow the steps below.

1. Extends a class from `Injector<T>` or other generic version of `Injector`, and override its abstract `Inject` method.

   ```c#
   public class ExampleInjector : Injector<string>
   {
       public override void Inject(string t)
       {
           services.AddTransient<Interface, Implication>();
       }
   }
   ```

2. Add following codes at the first line in `Main` method.

   ```c#
   var provider = Startup.ConfigureServices("value");
   // or, if you don't need a provider
   Startup.ConfigureServices("value");
   ```

   Using the one parameter version of `ConfigureServices` if your injector is extended from one type parameter `Injector`, there are 6 different `Injector`s and 6 different `ConfigureServices`s.

   |           `Injector`           |                   `ConfigurationServices`                    |
   | :----------------------------: | :----------------------------------------------------------: |
   |           `Injector`           |                    `ConfigureServices()`                     |
   |         `Injector<T>`          |                 `ConfigureServices<T>(T t)`                  |
   |       `Injector<T1, T2>`       |          `ConfigureServices<T1, T2>(T1 t1, T2 t2)`           |
   |     `Injector<T1, T2, T3>`     |     `ConfigureServices<T1, T2, T3>(T1 t1, T2 t2, T3 t3)`     |
   |   `Injector<T1, T2, T3, T4>`   | `ConfigureServices<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)` |
   | `Injector<T1, T2, T3, T4, T5>` | `ConfigureServices<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)` |

For **Autofac**, follow the steps below.

1. Add [Autofac.Extensions.DependencyInjection](https://www.nuget.org/packages/Autofac.Extensions.DependencyInjection) package into you project.

2. Extends a class from `AutofacInjector<T>` or other generic version of `AutofacInjector`, and override its `Inject` method.

   ```c#
   public class ExampleInjector : AutofacInjector<string>
   {
       public override IServiceProvider Inject(string t)
       {
           // Create the container builder.
           var builder = new ContainerBuilder();
           // register your service
           // ...
           var container = builder.Build();
       }
   }
   ```

3. Extends a class from `AutofacInjectorAdapter<T>` or other generic version of `AutofacInjectorAdapter`, and keep it empty.

   ```c#
   public class ExampleAdapter : AutofacInjectorAdapter<string>
   {
       // nothing in here
   }
   ```

4. Add following codes at the first line in `Main` method.

   ```c#
   var provider = Startup.ConfigureServices("value");
   // or, if you don't need a provider
   Startup.ConfigureServices("value");
   ```

   The rules are as same as the rules using the non Autofac, the relations between `AutofacInjector`, `AutofacInjectorAdapter` and `ConfigureServices` is listed(not all of them) below.

   |  `AutofacInjector`   |  `AutofacInjectorAdapter`   |     `ConfigureServices`     |
   | :------------------: | :-------------------------: | :-------------------------: |
   | `AutofacInjector<T>` | `AutofacInjectorAdapter<T>` | `ConfigureServices<T>(T t)` |
   |         ...          |             ...             |             ...             |

Enjoy injecting with parameters!