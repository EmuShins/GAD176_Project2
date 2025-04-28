using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CombatSystem
{
    /// <summary>
    /// Handles attacking, throwing, equipping weapons
    /// (Attach this script to your Player GameObject)
    /// (Set Weapon Layer Mask to the layer Weapon, if there is non then create one)
    /// </summary>
    public class CombatController : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Weapon currentWeapon; // Currently equipped weapon
        [SerializeField] private float pickupRadius = 2.0f;
        [SerializeField] private LayerMask weaponLayerMask;

        #endregion

        #region Update
        // Update is called once per frame
        void Update()
        {
            HandlePickup();
            HandleSwing();
            HandleThrow();

        }

        #endregion

        #region Pickup radius Gizmos
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, pickupRadius);

        }

        #endregion

        #region Handles
        private void HandlePickup()
        {
            // Input for picking up using E key
            if (currentWeapon == null && Input.GetKeyDown(KeyCode.E))
            {
                // Find all colliders with radius on the weapon layer
                Collider[] hits = Physics.OverlapSphere(transform.position, pickupRadius, weaponLayerMask);
                
                foreach (Collider hit in hits)
                {
                    // Attempt to get weapon component on object or parent
                    Weapon weapon = hit.GetComponentInParent<Weapon>();
                    if (weapon != null && weapon.gameObject.activeSelf)
                    {
                        EquipWeapon(weapon);
                        weapon.gameObject.SetActive(false);
                        Debug.Log("Picked up " + weapon.name);
                        break;

                    }

                }
            }

        }

        private void HandleSwing()
        {
            // Input for attacking using left mouse button
            if (Input.GetMouseButtonDown(0) && currentWeapon != null)
            {
                currentWeapon.Swing(transform);

            }

        }

        private void  HandleThrow()
        {
            // Input for throwing using right mouse button
            if (Input.GetMouseButtonDown(1) && currentWeapon != null)
            {
                Vector3 throwDirection = transform.forward; // Adjust based on player input
                currentWeapon.ThrowWeapon(throwDirection);

                currentWeapon = null; // Clear current weapon after throwing

            }

        }
        #endregion

        #region Equip
        // Called when WeaponPickup or WeaponSpawner equips a weapon
        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            weapon.transform.parent = transform;
            weapon.PickUp(); 

        }
        #endregion

    }
}