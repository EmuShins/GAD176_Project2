using Unity.VisualScripting;
using UnityEngine;

namespace CombatSystem
{
    /// <summary>
    /// Implement Swing() and ThrowWeapon() using player's position.
    /// (Attach this script to a new GameObject to define it as a weapon)
    /// (Set GameObject's layer as Weapon, if there is non then create one)
    /// (Make sure to set the GameObject as a prefab afterwards)
    /// </summary>
    public class DefaultWeapon : Weapon
    {
        [SerializeField] private WeaponData weaponData; // weapon's data asset reference

        #region Awake
        void Awake()
        {
            if (weaponData != null )
            {
                weaponName = weaponData.weaponName;
                description = weaponData.description;
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

        #region Swinging
        // Melee swing attack using raycasting to detect hits
        public override void Swing(Transform attacker)
        {
            // Center the sphere in front of player halfway
            Vector3 center = attacker.position + attacker.forward * (swingRange * 0.5f);

            // OverlapSphere finds all colliders within swingRange radius
            Collider[] hits = Physics.OverlapSphere(center, swingRange);

            bool hitSomething = false;
            foreach (var col in hits)
            {
                if (!col.CompareTag("Enemy"))
                {
                    continue;

                }

                // Vector line from player to enemy
                Vector3 toEmemy = col.transform.position - attacker.transform.position;

                // Distance between enemy is to swingRange
                float dist = toEmemy.magnitude;
                if (dist > swingRange)
                {
                    continue;

                }

                // Destroy enemy if they are within 60 degrees forward
                float angle = Vector3.Angle(attacker.forward, toEmemy);
                if (angle > 60f)
                {
                    continue;

                }

                // Confirm hit
                Debug.Log(weaponName + " swung and destroyed enemy");
                Destroy(col.gameObject);
                hitSomething = true;

            }

            if (!hitSomething)
            {
                Debug.Log(weaponName + " swung and hit nothing");

            }


        }

        #endregion

        #region Throwing
        // Throw weapon using physics using force in a specified direction
        public override void ThrowWeapon(Vector3 direction)
        {
            Transform playerTransform = transform.parent; // Save player transform before detaching
            transform.parent = null; // Clear parent (the player)

            // Ensure weapon has a Ridgidbody
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = GetComponent<Rigidbody>();

            }

            gameObject.SetActive(true);

            // Move weapon launch point in front of the player gameObject
            float forwardOffset = 1.0f;
            float upwardOffeset = 1.2f;
            Vector3 spawnPos = playerTransform.position + playerTransform.forward * forwardOffset + Vector3.up * upwardOffeset;
            transform.position = spawnPos;

            // Reset existing velocity
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Apply force for throwing weapon
            rb.AddForce(throwForceMultiplier * weight * direction.normalized, ForceMode.Impulse);

            Debug.Log(weaponName + " thrown from " + spawnPos + " in direction " + direction + " with force " + throwForceMultiplier * weight);

        }
        #endregion
    }
}
