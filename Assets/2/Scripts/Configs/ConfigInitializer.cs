using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace HW.Second
{
    public class ConfigInitializer
    {
        private readonly Dictionary<string, object> _configs = new();
        private readonly Dictionary<string, (Type type, string label)> _configLabels;

        public ConfigInitializer(Dictionary<string, (Type type, string label)> configLabels)
        {
            _configLabels = configLabels;
        }

        public async Task InitializeAsync()
        {
            foreach (var (key, (type, label)) in _configLabels)
            {
                if (type == typeof(Player))
                {
                    ConfigLoader<Player> loader = new ConfigLoader<Player>();
                    _configs[key] = await loader.Load(label);
                }
                else if (type == typeof(InAppPackageConfig))
                {
                    ConfigLoader<InAppPackageConfig> loader = new ConfigLoader<InAppPackageConfig>();
                    _configs[key] = await loader.Load(label);
                }
                else
                {
                    throw new Exception($"Unsupported config type: {type.Name}");
                }
            }
        }

        public T GetConfig<T>(string key) where T : class
        {
            if (_configs.TryGetValue(key, out object config))
            {
                return config as T ?? throw new Exception($"Config with key {key} is not of type {typeof(T).Name}");
            }

            throw new Exception($"Config with key {key} not found.");
        }
    }
}