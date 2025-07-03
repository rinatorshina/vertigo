using System.Collections;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private Transform[] StartPoints;
    [SerializeField] private Transform[] EndPoints;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private float SpawnTimer;

    private void Start()
    {
        StartCoroutine(enemyTimer());
    }

    private void spawnEnemy()
    {
        int spawnInt = Random.Range(0, StartPoints.Length);
        GameObject Enemy = Instantiate(EnemyPrefab, StartPoints[spawnInt].transform.position, Quaternion.identity);
        Enemy.GetComponent<EnemyMovement>().endPoint = EndPoints[Random.Range(0, EndPoints.Length)];

    }

    private IEnumerator enemyTimer()
    {
        yield return new WaitForSeconds(SpawnTimer);
        spawnEnemy();
        StartCoroutine(enemyTimer());
    }

}
