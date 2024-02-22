using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZongDemo.Core
{
    /// <summary>
    ///     Note: Simple ServiceLocator
    ///     Limitations: It doesn't handle different scenes and global services, but it is good enough for the Demo.
    /// </summary>
    public class ServiceLocator : MonoBehaviour
    {
        private readonly Dictionary<Type, object> _services = new();
        public IEnumerable<object> RegisteredServices => _services.Values;

        private const string GAMEOBJECT_NAME = "ServiceLocator [Auto Created]";

        private static ServiceLocator s_instance;
        public static ServiceLocator Instance
        {
            get
            {
                if (s_instance != null)
                {
                    return s_instance;
                }

                if (FindFirstObjectByType<ServiceLocator>() is { } found)
                {
                    s_instance = found;
                    return found;
                }

                var obj = new GameObject(GAMEOBJECT_NAME);
                s_instance = obj.AddComponent<ServiceLocator>();
                return s_instance;
            }
        }

        public bool TryGet<T>(out T service) where T : class
        {
            var type = typeof(T);
            if (_services.TryGetValue(type, out var obj))
            {
                service = obj as T;
                return true;
            }

            service = null;
            return false;
        }

        public T Get<T>() where T : class
        {
            var type = typeof(T);
            if (_services.TryGetValue(type, out var obj))
            {
                return obj as T;
            }

            throw new ArgumentException($"ServiceLocator.Get: Service of type {type.FullName} not registered");
        }

        public ServiceLocator Register<T>(T service)
        {
            var type = typeof(T);

            if (!_services.TryAdd(type, service))
            {
                Debug.LogError($"ServiceLocator.Register: Service of type {type.FullName} already registered");
            }

            return this;
        }

        public ServiceLocator Register(Type type, object service)
        {
            if (!type.IsInstanceOfType(service))
            {
                throw new ArgumentException("Type of service does not match type of service interface", nameof(service));
            }

            if (!_services.TryAdd(type, service))
            {
                Debug.LogError($"ServiceLocator.Register: Service of type {type.FullName} already registered");
            }

            return this;
        }

        public ServiceLocator Unregister<T>()
        {
            var type = typeof(T);

            if (!_services.ContainsKey(type))
            {
                Debug.LogError($"ServiceLocator.Unregister: Service of type {type.FullName} not found");
            }
            else
            {
                _services.Remove(type);
            }

            return this;
        }

        // Handles domain reload
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Reset()
        {
            s_instance = null;
        }
    }
}