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

   
}
