using UnityEngine;

namespace CombatSystem
{
    /// <summary>
    /// ScriptableObject to define weapon stats
    /// (Create ScriptableObject via asset menu)
    /// (Attach ScriptableObject to Weapon Data under Default Weapon Script inside Inspector)
    /// </summary>

    [CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/Combat/Weapon Data", order = 0)]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public string description;
        public float weight;
        public float swingRange = 2f;
        public float throwForceMultiplier = 5f;

    }
}