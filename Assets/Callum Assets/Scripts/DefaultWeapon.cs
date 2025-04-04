using Unity.VisualScripting;
using UnityEngine;

namespace CombatSystem
{
    /// Weapon system that supports swinging and throwing actions
    public class DefaultWeapon : Weapon
    {
        [SerializeField] private WeaponData weaponData; // weapon's data asset reference

        #region Awake
        void Awake()
        {
            //
            if (weaponData != null )
            {
                weaponName = weaponData.weaponName;
                description = weaponData.description;
                attackPower = weaponData.attackPower;
                weight = weaponData.weight;
                swingRange = weaponData.swingRange;
                throwForceMultiplier = weaponData.throwForceMultiplier;

            }
            else
            {
                Debug.LogError("weaponData asset not assigned.");

            }
        }
        #endregion

        #region Swinging + Throwing
        // Melee swing attack using raycasting to detect hits
        public override void Swing()
        {
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward;

            // Raycast is used to detect enemy within swing range
            if (Physics.Raycast(origin, direction, out RaycastHit hit, swingRange))
            {
                if (hit.collider != null && hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log(weaponName + " hits enemy: " + hit.collider.name + " for " + attackPower + " damage.");
                    // (Call function here to reduce enemy health)

                }
                else if(hit.collider != null)
                {
                    Debug.Log(weaponName + " hits " + hit.collider.name);

                }
            }
            else
            {
                Debug.Log(weaponName + " swings and misses");

            }
        }

        // Throw weapon using physics using force in a specified direction
        public override void ThrowWeapon(Vector3 direction)
        {
            // Ensure weapon has a Ridgidbody
            if (TryGetComponent<Rigidbody>(out var rb))
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }

            // Detach from parent (If attached to player), enable object in world
            transform.parent = null;
            gameObject.SetActive(true);

            // Apply force for throwing weapon
            rb.AddForce(throwForceMultiplier * weight * direction.normalized, ForceMode.Impulse);
            Debug.Log(weaponName + " thrown with force " + throwForceMultiplier * weight + " in direction " + direction);

        }
        #endregion
    }
}
