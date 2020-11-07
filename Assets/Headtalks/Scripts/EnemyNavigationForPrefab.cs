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

        var destination = players.Length == 0 ? transform.position : players[0].gameObject.transform.position;

        navMeshAgent.SetDestination(destination);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, senseRadius);
    }
}
