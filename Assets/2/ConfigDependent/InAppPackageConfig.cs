using UnityEngine;

namespace HW.Second
{
    [CreateAssetMenu(fileName = "InAppConfig", menuName = "ScriptableObjects/InApp", order = 1)]
    public class InAppPackageConfig : ScriptableObject
    {
        [field: SerializeField] public float Price { get; private set; }
    }
}