using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection, ICoreModule[] modules) // bütün injection ve modülleri kontrol etmemizi sağlar 
        {
            foreach (var module in modules)// bütün modülleri gez 
            {
                module.Load(serviceCollection);// her modülü yükle
            }
            return ServiceTool.Create(serviceCollection);// modülü oluştur
        }
    }
}
