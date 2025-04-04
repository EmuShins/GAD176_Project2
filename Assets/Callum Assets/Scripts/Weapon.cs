using UnityEngine;

namespace CombatSystem
{
    /// Abstact base class for weapons
    /// Common traits and public API for all weapons
    public abstract class Weapon : MonoBehaviour
    {
        #region Variables
        protected string weaponName;            // Name of weapon
        protected string description;           // Description of weapon
        protected int attackPower;              // Damage output value
        protected float weight;                 // Mass of weapon influencing throwing/swinging
        protected float swingRange;             // Range of detection from melee swings
        protected float throwForceMultiplier;   // Force multiplier for throwing weapon

        #endregion

        #region Weapon Mechanics
        // Called when a weapon is picked up by the player
        public virtual void PickUp()
        {
            // Disable object in the world
            gameObject.SetActive(false);
            Debug.Log(weaponName + " picked up.");

        }

        // Melee swing attack
        public abstract void Swing();

        // Throw weapon
        public abstract void ThrowWeapon(Vector3 direction);

        #endregion 
    }
}
