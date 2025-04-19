using UnityEngine;

namespace CombatSystem
{
    ///  Spawn and assign a random weapon to player when they collide with spawner
    public class WeaponSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] weaponPrefabs; // Weapon prefabs list to spawn from

        private void Start()
        {
            Instantiate(weaponPrefabs[0], this.gameObject.transform);

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (weaponPrefabs.Length > 0)
                {
                    // Select a random weapon
                    int randomIndex = Random.Range(0, weaponPrefabs.Length);
                    GameObject setWeapon = Instantiate(weaponPrefabs[randomIndex], transform.position, Quaternion.identity);
                    Weapon weapon = setWeapon.GetComponent<Weapon>();

                    if (weapon != null)
                    {
                        // Get player's CombatController to equip weapon
                        CombatController controller = other.GetComponent<CombatController>();
                        if (controller != null)
                        {
                            controller.EquipWeapon(weapon);

                        }
                        else
                        {
                            Debug.LogError("CombatController component not assigned to Player");

                        }

                    }
                    else
                    {
                        Debug.LogError("Weapon component not assigned to spawned prefab");

                    }
                }
                else
                {
                    Debug.LogError("Weapon prefabs not assigned to WeaponSpawner");

                }

                // Destroy spawner after use
                Destroy(gameObject);

            }
        }

    }
}
