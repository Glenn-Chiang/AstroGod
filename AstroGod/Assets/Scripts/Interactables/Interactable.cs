using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected GameObject player;
    protected InteractSystem targetingSystem;
    public float distanceFromPlayer;

    [SerializeField] private GameObject interactPrompt;
 
    private void Awake()
    {
        player = GameObject.Find("Player");
        targetingSystem = player.GetComponent<InteractSystem>();
    }

    private void Update()
    {
        // The interactable object will be detected by the player if within range
        distanceFromPlayer = targetingSystem.CalculateDistance(this);
        bool inRange = distanceFromPlayer <= targetingSystem.range;

        if (inRange)
        {
            targetingSystem.AddItem(this);
        } else 
        { 
            targetingSystem.RemoveItem(this);
        }

        // Show interact prompt if this item is being targeted by the player
        interactPrompt.SetActive(targetingSystem.Target == this);
    }

    // This function is called when the player interacts with this object
    public abstract void OnInteract();
}