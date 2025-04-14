using UnityEngine;

namespace HW.Second
{
    public class PlayerPusher : MonoBehaviour
    {
        [SerializeField] private Bootstrap _bootstrap;
        
        private Player _player;

        public void SetBootstrap(Bootstrap bootstrap)
        {
            _bootstrap = bootstrap;
        }
        
        private async void Start()
        {
            await _bootstrap.WaitForInitialization();
            
            _player = _bootstrap.Configs.GetConfig<Player>("PlayerConfig");
        }

        private void Update()
        {
            transform.position += transform.forward * _player.StartingSpeed * Time.deltaTime;
        }
    }
}