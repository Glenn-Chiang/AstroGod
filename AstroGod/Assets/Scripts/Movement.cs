using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private readonly float minRoamDistance = 2;
    private readonly float maxRoamDistance = 10;
    private readonly float destinationThreshold = 1; // When the enemy is within this distance from the destination, it will be considered to have reached the destination

    private ICharacter character;
  
    private float MoveSpeed => character.Stats.moveSpeed.Value;
    private Vector2 startPosition;
    private Vector2 destination;

    private bool isWaiting = false;

    private void Awake()
    {
        startPosition = transform.position;
        destination = GetRoamDestination();
    }

    private void Start()
    {
        character = GetComponent<ICharacter>();
    }

    public void Roam()
    {
        if (isWaiting) return;
        transform.position = Vector2.MoveTowards(transform.position, destination, MoveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, destination) < destinationThreshold)
        {
            StartCoroutine(Wait());
            destination = GetRoamDestination();
        }
    }

    private IEnumerator Wait()
    {
        isWaiting = true;
        float waitTime = Random.Range(0.5f, 1);
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }

    // Randomly decide on a destination to roam towards
    private Vector2 GetRoamDestination()
    {
        var randomXDir = Random.Range(-1, 1);
        var randomYDir = Random.Range(-1, 1);
        var randomDirection = new Vector2(randomXDir, randomYDir);

        var randomDistance = Random.Range(minRoamDistance, maxRoamDistance);
        var destination = startPosition + randomDirection * randomDistance;
        return destination;
    }
}