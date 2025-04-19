using UnityEngine;

namespace CombatSystem
{
    /// Handles combat inputs and handles combat actions to equipped weapon
    /// (Attach to player object)
    public class CombatController : MonoBehaviour
    {
        [SerializeField] private Weapon currentWeapon; // Currently equipped weapon

        #region Update
        // Update is called once per frame
        void Update()
        {
            #region Swing Weapon
            // Input for attacking using left mouse button
            if (Input.GetMouseButtonDown(0) && currentWeapon != null)
            {
                currentWeapon.Swing(transform);
                Debug.Log("Swing");

            }

            #endregion

            #region Throw Weapon
            // Input for throwing using right mouse button
            if (Input.GetMouseButtonDown(1)  && currentWeapon != null)
            {
                Vector3 throwDirection = transform.forward; // Adjust based on player input
                currentWeapon.ThrowWeapon(throwDirection);

                currentWeapon = null; // Clear current weapon after throwing
                Debug.Log("Throw");

            }

            #endregion

        }

        #endregion

        // Called when WeaponPickup or WeaponSpawner equips a weapon
        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            weapon.transform.parent = transform;
            weapon.PickUp(); 

        }

        // Returns true if no weapon is currently equipped
        public bool NoWeaponEquipped()
        {
            return currentWeapon == null;

        }
    }
}