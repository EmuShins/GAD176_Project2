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
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.forward * swingRange);
        }

        // Melee swing attack using raycasting to detect hits
        public override void Swing(Transform attacker)
        {
            Vector3 origin = attacker.position + attacker.forward;
            Vector3 direction = attacker.forward;

            // Raycast is used to detect enemy within swing range
            if (Physics.Raycast(origin, direction, out RaycastHit hit, swingRange))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward));

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
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = GetComponent<Rigidbody>();

            }

            // Detach from parent (If attached to player)
            transform.parent = null;

            // Move to player position before throwing
            transform.position = Camera.main.transform.position + direction * 1.0f;

            gameObject.SetActive(true);

            rb.linearVelocity = Vector3.zero; // Reset existing velocity
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(throwForceMultiplier * weight * direction.normalized, ForceMode.Impulse); // Apply force for throwing weapon

            Debug.Log(weaponName + " thrown with force " + throwForceMultiplier * weight + " in direction " + direction);

        }
        #endregion
    }
}
