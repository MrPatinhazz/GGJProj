using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int _nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float _searchCtd = 1f;

    private SpawnState state = SpawnState.COUNTING;

    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[_nextWave]));
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive()
    {
        _searchCtd -= Time.deltaTime;
        if(_searchCtd <= 0f)
        {
            _searchCtd = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawn wave" + _wave.name);
        state = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        
        if(_nextWave + 1 > waves.Length -1)
        {
            _nextWave = 0;
            //can finish here
            Debug.Log("All waves completed");
        }
        else
        {
            _nextWave++;
        }
        
    }

    void SpawnEnemy (Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0,spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
