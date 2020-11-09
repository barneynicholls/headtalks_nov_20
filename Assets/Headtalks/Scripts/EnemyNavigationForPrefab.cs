using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavigationForPrefab : MonoBehaviour
{
    [SerializeField] float senseRadius = 20f;
    [SerializeField] LayerMask playerLayer;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        var players = Physics.OverlapSphere(transform.position,
                                            senseRadius,
                                            playerLayer);

        var destination = GetNearestPlayer(players);

        navMeshAgent.SetDestination(destination);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, senseRadius);
    }

    Vector3 GetNearestPlayer(Collider[] colliders)
    {
        Collider bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (var collider in colliders)
        {
            Vector3 directionToTarget = collider.transform.position - transform.position;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = collider;
            }
        }

        return bestTarget?.transform.position ?? transform.position;
    } 
}
