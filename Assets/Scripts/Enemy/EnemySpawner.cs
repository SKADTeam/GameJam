using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    public SpawnState state = SpawnState.COUNTING;

    public Transform enemy;

    public float TimeBetweenWaves = 5f;
    public float CountDown = 2f;
    private int waveIndex = 0;


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
        enemies.Add(Instantiate(enemy, transform.position, transform.rotation));
    }
}
