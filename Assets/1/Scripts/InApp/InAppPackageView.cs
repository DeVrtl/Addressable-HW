using System;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.Exceptions;

namespace HW.First
{
    public class InAppPackageView : MonoBehaviour
    {
        [SerializeField] private AssetReference _inAppPackage;
        [SerializeField] private TextMeshProUGUI _textMesh;
        
        private InAppPackageConfig _packageConfig;
        
        private void Start()
        {
            LoadConfig();
        }
        
        private async void LoadConfig()
        {
            AsyncOperationHandle<InAppPackageConfig> handle = _inAppPackage.LoadAssetAsync<InAppPackageConfig>();
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _packageConfig = handle.Result;
                
                _textMesh.text = string.Format(_textMesh.text, _packageConfig.Price.ToString());
            }
            else
            {
                throw new OperationException("Can't load an asset through addressable");
            }
        }
        
        private void OnDestroy()
        {
            if (_inAppPackage != null && _inAppPackage.IsValid())
                _inAppPackage.ReleaseAsset();
        }
    }
}