using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float sizeOfSpawnArea;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        var enemyCount = Random.Range(1, 5);

        for (int i = 0; i < enemyCount; i++)
        {
            var area = sizeOfSpawnArea / 2;

            var position = new Vector3(Random.Range(-area, area),
                                       transform.position.y,
                                       Random.Range(-area, area));

            Instantiate(enemyPrefab, position, Quaternion.identity);
        }

        yield return new WaitForSeconds(Random.Range(5f, 20f));

        StartCoroutine(SpawnEnemies());
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(sizeOfSpawnArea, sizeOfSpawnArea, sizeOfSpawnArea));
    }

}
