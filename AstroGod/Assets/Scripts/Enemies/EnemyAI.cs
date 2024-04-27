using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyMovement movement;

    private enum State
    {
        Idle,
        Aggro
    }

    private State state = State.Idle;


    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                movement.Roam();
                break;

            case State.Aggro:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Start aggro");
            state = State.Aggro;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Stop aggro");
            state = State.Idle;
        }
    }
}
