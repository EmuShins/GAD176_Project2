using CombatSystem;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private bool isPlayerInRange;
    private CombatController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            player = other.GetComponent<CombatController>();

        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            player = null;

        }


    }

    private void Update()
    {
        if (isPlayerInRange && player != null && Input.GetKeyDown(KeyCode.E))
        {
            Weapon weapon = GetComponentInParent<Weapon>();
            if (weapon != null && player.NoWeaponEquipped())
            {
                player.EquipWeapon(weapon);
                gameObject.SetActive(false);

            }

        }

    }
}
