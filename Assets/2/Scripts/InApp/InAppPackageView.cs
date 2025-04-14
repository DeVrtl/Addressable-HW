using System;
using TMPro;
using UnityEngine;

namespace HW.Second
{
    public class InAppPackageView : MonoBehaviour
    {
        [SerializeField] private Bootstrap _bootstrap;
        [SerializeField] private string _key;
        [SerializeField] private TextMeshProUGUI textMesh;
    
        private InAppPackageConfig _packageConfig;

        private void OnEnable()
        {
            textMesh.text = string.Format(textMesh.text, _packageConfig.Price.ToString());
        }

        private async void Start()
        {
            await _bootstrap.WaitForInitialization();
            
            _packageConfig = _bootstrap.Configs.GetConfig<InAppPackageConfig>(_key);
        }
    }
}