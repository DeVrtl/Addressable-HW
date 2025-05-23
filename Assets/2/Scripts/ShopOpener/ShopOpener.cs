using UnityEngine;

namespace HW.Second
{
    public class ShopOpener : MonoBehaviour
    {
        [SerializeField] private GameObject shop;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                shop.SetActive(!shop.activeSelf);
            }
        }
    }
}