using UnityEngine;

namespace HW.Second
{
    public class PlayerSummoner : MonoBehaviour
    {
        [SerializeField] private PlayerPusher prefab;
        [SerializeField] private Bootstrap _bootstrap;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                PlayerPusher pusher = Instantiate(prefab);
                pusher.SetBootstrap(_bootstrap);
            }
        }
    }
}