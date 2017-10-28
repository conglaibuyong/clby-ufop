using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace clby_ufop.Core.Misc
{
    public static class AutofacExtensions
    {
        public static IContainer ApplicationContainer { get; private set; }
        public static IServiceProvider Autofac(this IServiceCollection services, params IModule[] moduls)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            foreach (var m in moduls)
            {
                builder.RegisterModule(m);
            }
            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }


        public static T ResolveNamed<T>(string name)
        {
            if (ApplicationContainer.IsRegisteredWithName<T>(name))
            {
                return ApplicationContainer.ResolveNamed<T>(name);
            }

            return default(T);
        }


    }
}
