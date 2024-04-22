using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public PlayerMovement Movement { get; private set; }
    public PlayerInteraction InteractSystem { get; private set; }
    public PlayerInventory InventoryManager { get; private set; }
    public PlayerHealthManager HealthManager { get; private set; }

    [field: SerializeField] public int MaxAmmo { get; private set; }
    public AmmoManager AmmoManager => new(MaxAmmo);

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
        InventoryManager = GetComponent<PlayerInventory>();
        HealthManager = GetComponent<PlayerHealthManager>();
    }
}
