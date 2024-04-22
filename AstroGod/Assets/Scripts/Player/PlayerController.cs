using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public PlayerMovement Movement { get; private set; }
    public PlayerInteraction InteractSystem { get; private set; }
    public InventoryManager InventoryManager { get; private set; }

    [field: SerializeField] public CharacterStats CharacterStats { get; private set; } // Set in inspector
    public PlayerStats Stats => new(CharacterStats);
    public HealthManager HealthManager => new(Stats.MaxHealth.Value);
    public AmmoManager AmmoManager => new((int)Stats.MaxAmmo.Value);

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

        Movement = GetComponent<PlayerMovement>();
        InteractSystem = GetComponent<PlayerInteraction>();
        InventoryManager = GetComponent<InventoryManager>();   
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
