using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject friendPrefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 4f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(EnemySpawn), spawnRate, spawnRate);
        float friendSpawnRate = Random.Range(spawnRate+10, spawnRate+20);
        InvokeRepeating(nameof(FriendSpawn), friendSpawnRate, friendSpawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(EnemySpawn));
        CancelInvoke(nameof(FriendSpawn));
    }

    private void EnemySpawn()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity); ///Quaternion.identity means no rotation
        enemy.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }

    private void FriendSpawn()
    {
        GameObject friend = Instantiate(friendPrefab, transform.position, Quaternion.identity); ///Quaternion.identity means no rotation
        friend.transform.position += Vector3.up * Random.Range(-2f, 1f);
    }
}
