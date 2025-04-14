using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.Exceptions;

namespace HW.Second
{
    public class ConfigLoader<T>
    {
        public async Task<T> Load(string label)
        {
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(label);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                return handle.Result;
            }

            throw new OperationException("Can't load an asset through addressable");
        }
    
        public async Task<IList<T>> LoadAll(string label)
        {
            AsyncOperationHandle<IList<T>> handle = Addressables.LoadAssetsAsync<T>(label, null);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                return handle.Result;
            }

            throw new OperationException($"Can't load assets with label {label}");
        }
    }
}