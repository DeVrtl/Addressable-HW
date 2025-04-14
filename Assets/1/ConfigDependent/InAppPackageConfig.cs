using UnityEngine;

namespace HW.First
{
    [CreateAssetMenu(fileName = "InAppConfig", menuName = "ScriptableObjects/InApp", order = 1)]
    public class InAppPackageConfig : ScriptableObject
    {
        [field: SerializeField] public float Price { get; private set; }
    }
}