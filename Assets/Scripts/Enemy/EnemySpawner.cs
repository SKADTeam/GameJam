using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    public SpawnState state = SpawnState.COUNTING;

    public GameObject PlayerCharacter;

    public Transform enemy;

    public float TimeBetweenWaves = 5f;
    public float CountDown = 2f;
    private int waveIndex = 0;
    public int MaxEnemiesPerWave = 10;
    public int MinEnemiesPerWave = 5;

    public Vector2 SpawnAreaTopLeft;
    public Vector2 SpawnAreaBottomRight;
    


    private List<Transform> enemies = new List<Transform>();
   

    void Start()
    {
        StartCoroutine(RunSpawner());
    }

    private IEnumerator RunSpawner()
    {
        yield return new WaitForSeconds(CountDown);

        while (true)
        {
            state = SpawnState.SPAWNING;
            yield return SpawnWave();

            state = SpawnState.WAITING;

            yield return new WaitWhile(EnemyisAlive);

            state = SpawnState.COUNTING;

            yield return new WaitForSeconds(TimeBetweenWaves);
        }
    }

    private bool EnemyisAlive()
    {
        
        enemies = enemies.Where(e => e != null).ToList();

        return enemies.Count > 0;
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {

        Vector2 spawnPosition = new Vector2(Random.Range(SpawnAreaTopLeft.x, SpawnAreaBottomRight.x),
                                            Random.Range(SpawnAreaTopLeft.y, SpawnAreaBottomRight.y));

        if (Vector2.Distance(spawnPosition, PlayerCharacter.transform.position) < 5f)
        {
            return;
        }
        enemies.Add(Instantiate(enemy, transform.position, transform.rotation));
    }
}
