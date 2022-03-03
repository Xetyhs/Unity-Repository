using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WaveManager : MonoSingleton<WaveManager>
{
    
    [SerializeField] private List<Wave> waves;
    private int _waveIndex;

    /*--------------------------------------------------------------------*/
    
    [Header("Spawners")]
    [SerializeField] private Spawner enemySpawner;
    [SerializeField] private Spawner powerUpSpawner;
    
    /*--------------------------------------------------------------------*/
    
    private State _spawnerState;

    /*--------------------------------------------------------------------*/

    [Header("Countdown Settings")]
    public float countdownForWaves = 3f;
    public float countdownTransition = 5f;
    private float _countdown;

    /*--------------------------------------------------------------------*/

    private IEnumerator _waveSpawn;
    
    /*--------------------------------------------------------------------*/
    
    /*--------------------------------------------------------------------*/

    
    [SerializeField] private List<GameObject> enemies;
    private bool[,] proceduralWaves;
    
    public int waveCount;
    
    
    
    
    // Start is called before the first frame update

    private void Awake()
    {
        CreateProceduralWaves(waveCount);
        InitializeWaves();
        InitializeFields();
    }

    void Start()
    {
        InitializeSpawner();
        _countdown = countdownForWaves;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_spawnerState)
        {
            case State.Waiting:
                WaitingState();
                break;
            case State.Counting:
                CountingState();
                break;
            case State.Spawning:
                SpawningState();
                break;
        }


    }
    
    /*--------------------------------------------------------------------*/

    private void WaitingState()
    {
        if (_countdown > 0f)
        {
            _countdown -= Time.deltaTime;
            return;
        }
        _spawnerState = State.Counting;
        _countdown = countdownForWaves;

    }
    
    private void CountingState()
    {
        if (_countdown > 0f)
        {
            _countdown -= Time.deltaTime;
            return;
        }

        _waveSpawn = enemySpawner.Spawn(waves[_waveIndex].spawnCount);
        StartCoroutine(_waveSpawn);
        
        _spawnerState = State.Spawning;
        _countdown = countdownTransition;

    }
    
    private void SpawningState()
    {
        if(waves[_waveIndex].spawnCount > enemySpawner.GetSpawnedCount()) return;
        
        if(enemySpawner.AreEnemiesAlive()) return;
        
        UpdateWave();
        _spawnerState = State.Waiting;
        _countdown = countdownTransition;
    }
    

    /**
     * PlayerData has to be used here. BUT FIND A BETTER SOLUTION
     */
    private void UpdateWave()
    {
        //_waveIndex++;
        // Geçici kod
        if (_waveIndex == waves.Count - 1)
        {
            _waveIndex = 0;
        }
        else
        {
            _waveIndex++;
        }
        
        // Player.Instance kısmını durumsal olarak yorum satırına al.
        // Alttaki satırı PlayerData.Instance.Update() olarak değiştir.
        
        
        
        // When player goes into the next wave, its stats will be updated.
        // And the wave of the player is also updated.
        
        Player.Instance.PlayerData.NextData();
        enemySpawner.UpdateSpawnables(waves[_waveIndex].waveObjects);
    }
    
    
    /*--------------------------------------------------------------------*/

    
    private void CreateProceduralWaves(int waveCount)
    {
        proceduralWaves = new bool[waveCount, waveCount];
        bool[,] waveArr = new bool[waveCount + 1, waveCount];
        
        for (int j = waveCount - 1; j >= 0; j--)
        {
            int zeroOneCount = ((int)math.pow(2, j + 1) - 1)/2;
            bool writeZero = (zeroOneCount > 0);


            for (int i = 1; i < waveCount + 1; i++)
            {
                if (writeZero)
                {
                    waveArr[i, j] = false;
                }
                else
                {
                    waveArr[i, j] = true;
                }

                zeroOneCount--;
                if (zeroOneCount <= 0)
                {
                    zeroOneCount = (int)math.pow(2, j + 1)/2;
                    writeZero = !writeZero;
                }

            }
        }

        for (int i = 1; i <= waveCount; i++)
        {
            for (int j = 0; j < waveCount; j++)
            {
                proceduralWaves[i - 1, j] = waveArr[i, j];
            }
        }
        
        
    }

    private void InitializeWaves()
    {
        for (int i = 0; i < waveCount; i++)
        {
            List<GameObject> waveEnemies = new List<GameObject>();
            for (int j = 0; j < waveCount; j++)
            {
                if (proceduralWaves[i, j] == true)
                {
                    waveEnemies.Add(enemies[j]);
                }
            }

            waves.Add(new Wave {waveObjects = waveEnemies.ToArray(), spawnCount = waveEnemies.ToArray().Length * 30});
        }
    }

    /**
     * PlayerData has to be used here. BUT FIND A BETTER SOLUTION
     */
    private void InitializeFields()
    {
        // For initializing the waveIndex as the latest wave of the player.
        _waveIndex = Player.Instance.PlayerData.waveCheckpoint;
        _waveSpawn = enemySpawner.Spawn(waves[_waveIndex].spawnCount);
    }

    private void InitializeSpawner()
    {
        enemySpawner.spawnerData.pool.WakeAllObjectsAs(waves[_waveIndex].waveObjects);
        _spawnerState = State.Counting;
    }
}
