using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public PlayerMovement Movement { get; private set; }
    public InteractSystem InteractSystem { get; private set; }
    public PlayerInventory InventoryManager { get; private set; }

    [field: SerializeField] public CharacterStats CharacterStats { get; private set; } // Set in inspector
    public PlayerStats Stats { get; private set; }
    
    public HealthManager HealthManager { get; private set; }
    public AmmoManager AmmoManager { get; private set; }

    private bool isAlive = true;

    private void Awake()
    {
        // Ensure there is only 1 instance of singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        } 
        Instance = this;

        Stats = new(CharacterStats);
        Movement = GetComponent<PlayerMovement>();
        InteractSystem = GetComponent<InteractSystem>();
        InventoryManager = GetComponent<PlayerInventory>();

        HealthManager = GetComponent<HealthManager>();
        HealthManager.Initialize(Stats.MaxHealth.Value);

        AmmoManager = GetComponent<AmmoManager>();
        AmmoManager.Initialize((int)Stats.MaxAmmo.Value);
    }

    private void Update()
    {
        //if (isAlive && HealthManager.Health == 0)
        //{
        //    Die();
        //}
    }

    private void Die()
    {
        isAlive = false;
        Debug.Log("Player died");
        //Destroy(Instance);
    }
}
