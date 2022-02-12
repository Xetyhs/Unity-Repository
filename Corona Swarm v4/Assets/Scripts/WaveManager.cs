using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    public List<Wave> waves;
    private int _waveIndex = 0;

    /*--------------------------------------------------------------------*/
    
    public Spawner enemySpawner;
    
    /*--------------------------------------------------------------------*/
    
    private State _spawnerState;

    /*--------------------------------------------------------------------*/

    public float countdownForWaves = 3f;
    public float countdownTransition = 5f;
    private float _countdown;

    /*--------------------------------------------------------------------*/

    private IEnumerator _waveSpawn;
    
    /*--------------------------------------------------------------------*/
    
    // Start is called before the first frame update

    private void Awake()
    {
        _waveSpawn = enemySpawner.Spawn();
        _waveIndex = 0;
    }

    void Start()
    {
        enemySpawner.spawnerData.pool.WakeAllObjectsAs(waves[_waveIndex].waveObjects);
        _spawnerState = State.Counting;
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
    
    /*  COUROUTINES */
    /*
     * 
A coroutine is not a method. A coroutine is a statemachine object. 
When you call your "generator method" it actually creates a statemachine which is returned. 
You create those inside Start. 
When you pass this statemachine object to StartCoroutine you essentially "register" this instance to Unity's coroutine scheduler,
and it starts "iterating" the statemachine. 
Based on the yielded values the scheduler determines when this coroutine should be re-scheduled the next time.

When you call StopCoroutine 
you just "unregister" that statemachine, 
however the current execution will run up to the next yield statement. 
Since the coroutine is no longer registered it will essentially stop there. 
However when you pass the same statemachine instance again to StartCoroutine 
it is still in the last state it was before so you essentially continue where you left off the last time. 
If the coroutine / statemachine actually reached the end 
(actually reaching the end or if it hits a yield break statement) the coroutine is essentilly dead. 
Passing it again to StartCoroutine has no effect since when Unity's scheduler tries to run the "next step" 
MoveNext will just return false since the statemachine reached the end.

To actually restart the coroutine you have to create a new statemachine. 
So you have to call your generator methods again (SoldierHealTimer and SoldierHealingToFull) to get a new, fresh statemachine. 
However as mentioned above you just overcomplicate everything by using several coroutines. 
Creating such a statemachine will allocate memory. Starting and stopping coroutines also isn't for free. 
So it makes more sense to use a single coroutine that runs always in the background and does everything.
     */
    
    
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
        // 116. SATIRI BİR ŞEKİLDE OPTİMİZE ETMENİN YOLUNU BUL.
        _waveSpawn = enemySpawner.Spawn();
        StartCoroutine(_waveSpawn);
        _spawnerState = State.Spawning;
        _countdown = countdownTransition;

    }
    
    private void SpawningState()
    {
        if(waves[_waveIndex].spawnCount > enemySpawner.GetSpawnedCount())
            return;
        
        StopCoroutine(_waveSpawn);

        if(enemySpawner.AreEnemiesAlive())
            return;
        
        _spawnerState = State.Waiting;
        _countdown = countdownTransition;
        UpdateWave();
    }


    private void UpdateWave()
    {
        _waveIndex++;
        enemySpawner.UpdateSpawnables(waves[_waveIndex].waveObjects);
    }
    
    
    
    //private void WaveSpawn()
    //{
        // Array'de gösterilen wave'i gidip spawnla
        // Spawner'ın poolundaki objeleri, wave'deki waveObjects objelerinden belirle.
        // Eğer waveObjects'in length'i 1'den fazla ise, poolindeki objeler de buradaki objelerden random seçilerek poola koyulsun.
        // Ardından Spawner.Instance.SpawnMethod() yaparak hespinin spawnlanmasını sağla.
        // Spawner'da Bir spawnlanma sayısı attribute'u yaz, bu 0'dan başlasın ve haritada ne kadar obje yaratılmış ise onu belirtsin.
        // Eğer WaveManager'daki Wave'in spawnCount'u geçerse, wave tamamlansın.
    //}
}
