using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject goblinFighter;
    public GameObject goblinWolf;
    public GameObject goblinArcher;
    public Transform player;
    public float spawnRadius;
    public float spawnInterval;
    private float timer;
    [SerializeField] private PlayerXp playerXp;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            if(playerXp.level <= 3)
            {
                SpawnGoblinFighter();
            } 
            else if(playerXp.level <= 7)
            {
                spawnInterval = 1.5f;
                SpawnGoblinFighter();
                SpawnGoblinWolf();
            } 
            else if(playerXp.level <= 9)
            {
                spawnInterval = 1;
                SpawnGoblinWolf();
            } 
            else if(playerXp.level <= 12)
            {
                spawnInterval = 1.5f;
                SpawnGoblinWolf();
                SpawnGoblinArcher();
            } 
            else if(playerXp.level <= 18)
            {
                spawnInterval = 1.2f;
                SpawnGoblinFighter();
                SpawnGoblinArcher();
                SpawnGoblinWolf();
            } else 
            {
                spawnInterval = 0.5f;
                SpawnGoblinFighter();
                SpawnGoblinArcher();
                SpawnGoblinWolf();
            }

            
            timer = 0;
        }
    }

    void SpawnGoblinFighter()
    {
        Vector2 spawnPos = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(goblinFighter, spawnPos, Quaternion.identity);
    }
    void SpawnGoblinWolf()
    {
        Vector2 spawnPos = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(goblinWolf, spawnPos, Quaternion.identity);
    }
    void SpawnGoblinArcher()
    {
        Vector2 spawnPos = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(goblinArcher, spawnPos, Quaternion.identity);
    }
}
