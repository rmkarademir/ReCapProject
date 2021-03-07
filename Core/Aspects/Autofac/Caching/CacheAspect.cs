using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Caching;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//ReflectedType = namespace kısmı, FullName = interface varsa interface yoksa classın ismi, Method name = çalışacak metodun adı
                                                                                                                   // Business.Abstract.IProductService.Getall gibi         
            var arguments = invocation.Arguments.ToList();// metodun parametrelerini liste haline getir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//methodName parametreleri aralarına ',' koyarak ekle(string.Join), ?? = veya gibi öncesindeki yoksa ,parametre yoksa null yani boş bırak 
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);// bu key ile daha önce cache yapıldıysa, cacheManager ile getirilir, returnValue = return değeri oluştur
                return;
            }
            invocation.Proceed();// metodu çalıştır, devam et
            _cacheManager.Add(key, invocation.ReturnValue, _duration);// cache ekle
        }
    }
}
