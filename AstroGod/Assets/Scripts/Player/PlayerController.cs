using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public PlayerMovement Movement { get; private set; }
    public PlayerInteraction InteractSystem { get; private set; }

    public InventoryManager InventoryManager { get; } = new();
    public WeaponInventory WeaponInventory { get; } = new();
    public ArmorInventory ArmorInventory { get; } = new();

    private void Awake()
    {
        // Ensure there is only 1 instance of singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        } 

        Instance = this;

        Movement = GetComponent<PlayerMovement>();
        InteractSystem = GetComponent<PlayerInteraction>();
    }

    private int? GetNumberInput()
    {
        KeyCode[] numberKeys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
        for (int i = 0; i < numberKeys.Length; i++)
        {
            if (Input.GetKeyDown(numberKeys[i]))
            {
                return i + 1;
            }
        }
        return null;
    }
}
