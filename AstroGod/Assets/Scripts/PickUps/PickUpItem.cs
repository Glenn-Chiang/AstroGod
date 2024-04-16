using TMPro;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private GameObject pickUpPrompt;
    
    private PickUpTargeting targetingSystem;
    public float distanceFromPlayer;

    private void Start()
    {
        var player = GameObject.Find("Player");
        targetingSystem = player.GetComponent<PickUpTargeting>();
    }

    private void Update()
    {
        // If player is within range, show pickup prompt
        distanceFromPlayer = targetingSystem.CalculateDistance(this);
        bool inRange = distanceFromPlayer <= targetingSystem.range;

        if (inRange)
        {
            targetingSystem.AddItem(this);
        } else 
        { 
            targetingSystem.RemoveItem(this);
        }

        // Show pick-up prompt if this item is being targeted by the player
        pickUpPrompt.SetActive(targetingSystem.Target == this);
    }
}