using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAIForPrefab : MonoBehaviour
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

        var nearestPlayer = GetNearestPlayer(players);

        navMeshAgent.SetDestination(nearestPlayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, senseRadius);
    }

    Vector3 GetNearestPlayer(Collider[] colliders)
    {
        Collider nearestCollider = null;
        float closestDistance = Mathf.Infinity;

        foreach (var collider in colliders)
        {
            Vector3 directionToTarget = collider.transform.position - transform.position;
            float distance = directionToTarget.sqrMagnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestCollider = collider;
            }
        }

        return nearestCollider?.transform.position ?? transform.position;
    } 
}
