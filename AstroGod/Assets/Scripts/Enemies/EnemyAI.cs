using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Movement movement;

    private enum State
    {
        Idle,
        Aggro
    }

    private State state = State.Idle;

    private GameObject target; // Currently attacking this target

    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                movement.Roam();
                break;

            case State.Aggro:
                Aggro();
                break;
        }
    }

    private void Aggro()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            state = State.Aggro;
            target = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            state = State.Idle;
            target = null;
        }
    }
}
