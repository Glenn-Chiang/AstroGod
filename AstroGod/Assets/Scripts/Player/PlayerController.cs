using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacter
{
    public static PlayerController Instance { get; private set; }

    public PlayerMovement Movement { get; private set; }
    public InteractionManager InteractSystem { get; private set; }
    public PlayerInventoryManager InventoryManager { get; private set; }

    [SerializeField] private PlayerCharacterData data;
    CharacterData ICharacter.Data => data;

    private PlayerStats stats;
    CharacterStats ICharacter.Stats => stats;
    
    public HealthManager HealthManager { get; private set; }
    public AmmoManager AmmoManager { get; private set; }


    private void Awake()
    {
        // Ensure there is only 1 instance of singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        } 
        Instance = this;

        stats = new(data);
        InteractSystem = GetComponent<InteractionManager>();
        InventoryManager = GetComponent<PlayerInventoryManager>();

        Movement = GetComponent<PlayerMovement>();
        Movement.Initialize(stats.moveSpeed);
        
        HealthManager = GetComponent<HealthManager>();

        AmmoManager = GetComponent<AmmoManager>();
        AmmoManager.Initialize((int)stats.maxAmmo.Value);
    }

    private void Die()
    {
        
        Debug.Log("Player died");
        //Destroy(Instance);
    }
}
