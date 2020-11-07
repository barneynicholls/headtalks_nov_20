using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.position);
    }
}
