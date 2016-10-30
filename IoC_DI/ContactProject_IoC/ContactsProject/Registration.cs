using Data.BL;
using Data.Data;
using Data.Infrostructure;
using Data.Model;
using Microsoft.Practices.Unity;

namespace ContactsProject
{
   public static class Registration
    {
       public static void PrepareRegistration(IUnityContainer unityContainer)
       {
           // регистрация типов
           unityContainer.RegisterType<ILogger, ConsoleLogger>("consoleLogger", new ContainerControlledLifetimeManager());
           unityContainer.RegisterType<ILogger, FileLogger>("fileLoger", new ContainerControlledLifetimeManager());
           unityContainer.RegisterType<ConsoleWriter>("consoleWriter", new ContainerControlledLifetimeManager());
           unityContainer.RegisterType<FileWriter>("fileWriter", new ContainerControlledLifetimeManager());

           var exceptionHandlerWithConsoleLogger = GetExceptionHandlerByLoggerType<ExceptionHandler, ConsoleLogger>(unityContainer);

           unityContainer.RegisterType<WriterService>(new ContainerControlledLifetimeManager(), new InjectionConstructor(( unityContainer.Resolve<ConsoleWriter>())));
           unityContainer.RegisterType<EntityRepository<Contact>>(new ContainerControlledLifetimeManager(), new InjectionConstructor(exceptionHandlerWithConsoleLogger));
           unityContainer.RegisterType<EntityRepository<User>>(new ContainerControlledLifetimeManager(), new InjectionConstructor(exceptionHandlerWithConsoleLogger));
        }


       private static IExceptionHandler GetExceptionHandlerByLoggerType<TExceptionHandler, TLogger>(IUnityContainer unityContainer) where TLogger: class, ILogger, new()
           where TExceptionHandler : IExceptionHandler
       {
           var exceptionHanler = unityContainer.Resolve<TExceptionHandler>(new DependencyOverride(typeof(ILogger), typeof(TLogger)));

           return exceptionHanler;
       }
    }
}
