using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.Exceptions;

namespace HW.First
{
    public class PlayerPusher : MonoBehaviour
    {
        [SerializeField] private AssetReference _player;

        private Player _playerConfig;
        private bool _isLoaded = false;

        private void Start()
        {
            LoadConfig();
        }

        private async void LoadConfig()
        {
            AsyncOperationHandle<Player> handle = _player.LoadAssetAsync<Player>();
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _isLoaded = true;
                _playerConfig = handle.Result;
            }
            else
            {
                throw new OperationException("Can't load an asset through addressable");
            }
        }

        private void Update()
        {
            if (_isLoaded != false)
                transform.position += transform.forward * _playerConfig.StartingSpeed * Time.deltaTime;
        }

        private void OnDestroy()
        {
            if (_player != null && _player.IsValid())
                _player.ReleaseAsset();
        }
    }
}