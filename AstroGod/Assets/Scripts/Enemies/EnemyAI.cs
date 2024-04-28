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

    public void OnEnterAggroRadius(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            state = State.Aggro;
            target = obj;
        }

    }

    public void OnExitAggroRadius(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            state = State.Idle;
            target = null;
        }

    }
}
