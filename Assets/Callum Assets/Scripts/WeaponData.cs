using UnityEngine;

namespace CombatSystem
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/Combat/Weapon Data", order = 0)]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public string description;
        public int attackPower;
        public float weight;
        public float swingRange = 2f;
        public float throwForceMultiplier = 5f;

    }
}