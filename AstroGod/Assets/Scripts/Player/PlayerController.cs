using System;
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

    private HealthManager healthManager;
    public AmmoManager AmmoManager { get; private set; }

    public static event EventHandler OnPlayerDeath;

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
        
        healthManager = GetComponent<HealthManager>();
        healthManager.OnDeath += HandleDeath;

        AmmoManager = GetComponent<AmmoManager>();
        AmmoManager.Initialize((int)stats.maxAmmo.Value);
    }

    private void HandleDeath(object sender, EventArgs e)
    {
        Debug.Log("Player died");
        OnPlayerDeath?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }
}
