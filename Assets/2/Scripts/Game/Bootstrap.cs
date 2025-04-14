using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace HW.Second
{
    public class Bootstrap : MonoBehaviour
    {
        private ConfigInitializer _configs;
        private Task _initializationTask;

        public ConfigInitializer Configs => _configs;
        
        private readonly Dictionary<string, (Type type, string label)> _configLabels = new Dictionary<string, (Type, string)>
        {
            { "PlayerConfig", (typeof(Player), "SecondPlayer") },
            { "InAppConfig1", (typeof(InAppPackageConfig), "SecondInApp1") },
            { "InAppConfig2", (typeof(InAppPackageConfig), "SecondInApp2") },
            { "InAppConfig3", (typeof(InAppPackageConfig), "SecondInApp3") },
            { "InAppConfig4", (typeof(InAppPackageConfig), "SecondInApp4") }
        };

        private async void Awake()
        {
            _configs = new ConfigInitializer(_configLabels);
            _initializationTask = _configs.InitializeAsync();
            await _initializationTask;
        }
        
        public Task WaitForInitialization() => _initializationTask;
    }
}