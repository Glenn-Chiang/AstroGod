using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacter, IArmable
{
    public static PlayerController Instance { get; private set; }

    public PlayerMovement Movement { get; private set; }
    public InteractionManager InteractSystem { get; private set; }

    [SerializeField] private PlayerCharacterData data;
    CharacterData ICharacter.Data => data;

    public PlayerStats Stats { get; private set; }
    CharacterStats ICharacter.Stats => Stats;

    public HealthManager HealthManager { get; private set; }
    public AmmoManager AmmoManager { get; private set; }

    public PlayerInventoryManager InventoryManager { get; private set; }
    InstanceInventory<Weapon> IArmable.WeaponInventory => InventoryManager.weaponInventory;
    
    public WeaponEquip WeaponEquip { get; private set; }

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

        Stats = new(data);
        InteractSystem = GetComponent<InteractionManager>();
        InventoryManager = GetComponent<PlayerInventoryManager>();
        
        Movement = GetComponent<PlayerMovement>();
        
        HealthManager = GetComponent<HealthManager>();
        HealthManager.OnDeath += HandleDeath;

        AmmoManager = GetComponent<AmmoManager>();
        WeaponEquip = GetComponentInChildren<WeaponEquip>();
    }

    private void HandleDeath(object sender, EventArgs e)
    {
        Debug.Log("Player died");
        OnPlayerDeath?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }
}
