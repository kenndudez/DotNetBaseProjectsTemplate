﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace DOTNET.BaseProjectTemplate.Core.Infrastructure.DependencyInjection
{
    public class ServiceLocator
    {
        private ServiceProvider _currentServiceProvider;
        private static ServiceProvider _serviceProvider;

        public ServiceLocator(ServiceProvider currentServiceProvider)
        {
            _currentServiceProvider = currentServiceProvider;
        }

        public static ServiceLocator Current
        {
            get
            {
                return new ServiceLocator(_serviceProvider);
            }
        }

        public static void SetLocatorProvider(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetInstance(Type serviceType)
        {
            return _currentServiceProvider.GetService(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return _currentServiceProvider.GetService<TService>();
        }
    }
}