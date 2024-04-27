using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private readonly float minRoamDistance = 2;
    private readonly float maxRoamDistance = 10;
    private readonly float destinationThreshold = 1; // When the enemy is within this distance from the destination, it will be considered to have reached the destination

    [SerializeField] private EnemyData enemyData;
    private float MoveSpeed => enemyData.MoveSpeed;

    private Vector2 startPosition;
    private Vector2 destination;

    private void Awake()
    {
        startPosition = transform.position;
        destination = GetRoamDestination();
    }

    public void Roam()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, MoveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, destination) < destinationThreshold)
        {
            destination = GetRoamDestination();
        }
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