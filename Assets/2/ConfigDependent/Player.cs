using UnityEngine;

namespace HW.Second
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/Player", order = 1)]
    public class Player : ScriptableObject
    {
        [field: SerializeField, Range(0f, 100f)] public float StartingHP { get; private set; }
        [field: SerializeField, Range(0f, 10f)] public float StartingSpeed{ get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float StartingAttack{ get; private set; }
    }
}