using UnityEngine;

namespace CombatSystem
{
    public abstract class Weapon : MonoBehaviour
    {
        protected string weaponName;            // Name of weapon
        protected string description;           // Description of weapon
        protected int attackPower;              // Damage output value
        protected float weight;                 // Mass of weapon influencing throwing/swinging
        protected float swingRange;             // Range of detection from melee swings
        protected float throwForceMultiplier;   // Force multiplier for throwing weapon

        // Called when a weapon is picked up by the player
        public virtual void PickUp()
        {
            // Disable weapon to pickup
            gameObject.SetActive(false);
            Debug.Log(weaponName + " picked up.");

        }

        // Melee swing attack
        public abstract void Swing();

        // Throw weapon
        public abstract void ThrowWeapon(Vector3 direction);
    }
}
