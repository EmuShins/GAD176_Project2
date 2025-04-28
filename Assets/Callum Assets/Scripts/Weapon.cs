using UnityEngine;

namespace CombatSystem
{
    /// <summary>
    /// Abstact base class for all weapons
    /// </summary>
    public abstract class Weapon : MonoBehaviour
    {
        #region Variables
        protected string weaponName;            // Name of weapon
        protected string description;           // Description of weapon
        protected float weight;                 // Mass of weapon influencing throwing/swinging
        protected float swingRange;             // Range of detection from melee swings
        protected float throwForceMultiplier;   // Force multiplier for throwing weapon

        #endregion

        #region Weapon Mechanics
        // Pick up weapon to equip
        public virtual void PickUp()
        { }

        // Melee swing attack
        public abstract void Swing(Transform transform);

        // Throw weapon
        public abstract void ThrowWeapon(Vector3 direction);

        #endregion 
    }
}
