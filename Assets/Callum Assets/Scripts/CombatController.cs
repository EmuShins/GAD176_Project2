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
            #region Equip Weapon
            // Pick up weapon using input E
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Find the first available DefaultWeapon
                Weapon pickup = FindFirstObjectByType<DefaultWeapon>();
                if (pickup != null)
                {
                    currentWeapon = pickup;
                    currentWeapon.PickUp();

                }
                else
                {
                    Debug.LogWarning("No weapon available to pick up.");

                }

            }
            #endregion

            #region Swing Weapon
            // Input for attacking using left mouse button
            if (Input.GetMouseButtonDown(1) && currentWeapon != null)
            {
                currentWeapon.Swing();

            }

            #endregion

            #region Throw Weapon
            // Input for throwing using right mouse button
            if (Input.GetMouseButtonDown(2)  && currentWeapon != null)
            {
                Vector3 throwDirection = transform.forward; // Adjust based on player input
                currentWeapon.ThrowWeapon(throwDirection);

                currentWeapon = null; // Clear current weapon after throwing

            }

            #endregion

        }

        #endregion

    }
}