using UnityEngine;

namespace HW.First
{
    public class PlayerSummoner : MonoBehaviour
    {
        [SerializeField] private PlayerPusher prefab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Instantiate(prefab);
            }
        }
    }
}