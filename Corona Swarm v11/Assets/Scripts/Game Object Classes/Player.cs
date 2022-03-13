using System.Collections;
using UnityEngine;

public class Player : MonoSingleton<Player>
{

    [SerializeField] private PlayerData _playerData;
    private long _score;
    private long _highscore;
    
    private PlayerData PlayerData => _playerData;
    [SerializeField] private GameObject wipeExplosion;
    [SerializeField] private GameObject healExplosion;
    
    private GameObject protectionShield;
    
    // PlayerData dangerous usage. Find a better solution for this.
    private void Awake()
    {
        _score = 0;
        _highscore = PlayerData.highScore;
        
        protectionShield = transform.Find("Protection Shield").gameObject;
        _playerData.InitializeData(false);

    }

    // Start is called before the first frame update
   
    void Update()
    {
        if(!Input.GetKey(KeyCode.Mouse0)) return;
        
        LookAtMouse();
    }
    
    private void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rotateDirection = mousePosition - transform.position;//transform.position;

        transform.up = rotateDirection;
    }

    /* ------------------------------------------- */

    public int GetCheckPoint()
    {
        return PlayerData.waveCheckpoint;
    }
    
    public long GetHighScore()
    {
        return PlayerData.highScore;
    }

    public void UpdateData()
    {
        _playerData.NextData();
    }
    // Function to get protection for seconds secs.

    /**
     *
     * Works Fine.
     */



    /**
     * PlayerData has to be used here. So no problem.
     */

    public bool IsAlive()
    {
        return _playerData.isAlive();
    }
    
    
    public IEnumerator GetProtection(float seconds = 0f)
    {
        _playerData.hasProtection = true;
        protectionShield.SetActive(true);
        if (seconds == 0)
        {
            yield return new WaitForSeconds(3);
        }
        else
        {
            yield return new WaitForSeconds(seconds);
        }
        protectionShield.SetActive(false);
        _playerData.hasProtection = false;
    }

    // Heals by hp, then gets protection for 1.5 secs.
    
    /**
     * PlayerData has to be used here. So no problem.
     */
    public IEnumerator Heal(int hp)
    {
        healExplosion.SetActive(true);
        _playerData.SetHealth(_playerData.GetHealth() + hp);
        yield return GetProtection(1.5f);
    }

    public void AddKillScore(int score)
    {
        this._score += score * _playerData.IngameScoreMultiplier + (Shield.Instance.GetKillCount() - Shield.Instance.comboTrigger);
    }

    public void WipeEnemies()
    {
        wipeExplosion.SetActive(true);
        WaveManager.Instance.WipeActiveEnemies();
    }

    // Takes damage, and gets protection for 3 secs.
    
    /**
     * PlayerData has to be used here. So no problem.
     */
    private IEnumerator TakeDamage(int damage, GameObject enemy)
    {
        if (_playerData.hasProtection)
            yield break;
        
        _playerData.DecreaseHealth(damage);
        
        if (!_playerData.isAlive())
        { 
            PlayerDeath(enemy);
        }
        yield return GetProtection();
    }
    
    
    
    
    
    private void PlayerDeath(GameObject enemyHit)
    {
        // When PLAYER dies, its current wave will be saved as checkpoint on PlayerData.
        // So, if player wants to restart, it can start from the latest wave.

        bool recordBroken = IsRecordBroken();
        
        ParticleManager.Instance.SpawnParticle(gameObject);
        UIManager.Instance.DeathAnimation(enemyHit, recordBroken, _score);
        _playerData.SetHighscore(_score);
        _playerData.SetCheckpoint();
        gameObject.SetActive(false);
        // DeathAnimation()

    }


    private bool IsRecordBroken()
    {
        return _score >= _highscore;
    }
    
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Enemy enemyObject))
        {
            StartCoroutine(TakeDamage(enemyObject.damage, col.gameObject));
        }
        
        if (col.gameObject.TryGetComponent(out HealOrb healOrbObject))
        {
            StartCoroutine(Heal(healOrbObject.healAmount));
        }

        if (col.CompareTag("Protection Orb"))
        {
            StartCoroutine(GetProtection());
        }

        if (col.CompareTag("Wipe Orb"))
        {
            WipeEnemies();
        }
        
    }
}
