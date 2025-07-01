using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _bindings = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsAssignableFrom(implementationType))
                throw new ArgumentException($"{implementationType} does not implement {interfaceType}");

            _bindings[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            var interfaceType = typeof(T);

            if (!_bindings.ContainsKey(interfaceType))
                throw new InvalidOperationException($"No binding found for {interfaceType}");

            var implementationType = _bindings[interfaceType];

            return (T)Activator.CreateInstance(implementationType);
        }
    }
}