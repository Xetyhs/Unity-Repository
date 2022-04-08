using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private long _highScore;
    
    
    [Range(1, 200)] [SerializeField] private int _ingameScoreMultiplier;
    private int _baseScoreMultiplier;
    private const int MAX_SCORE_MULTIPLIER = 256;
    private const int MIN_SCORE_MULTIPLIER = 1;
    
    [SerializeField] private int health;
    private const int MAX_HEALTH = 100;
    private const int MIN_HEALTH = 0;

    [SerializeField] private int _waveCheckpoint;
    // Arada denetlemek için [SerializeField] yap.
    private int _currentWave;

    private bool _hasProtection;


    public void InitializeData(bool startCheckpoint)
    {
        health = MAX_HEALTH;
        SetStartWave(startCheckpoint);
        hasProtection = false;
    }
    
    
    // Buraya bir powerup stack'i falan da koy.

    public int waveCheckpoint
    {
        get => _waveCheckpoint;
        private set => _waveCheckpoint = value;
    }
    
    
    public int currentWave
    {
        get => _currentWave;
        set => _currentWave = value;
    }
    public bool hasProtection
    {
        get => _hasProtection;
        set => _hasProtection = value;
    }
    public int IngameScoreMultiplier => _ingameScoreMultiplier;

    public long highScore
    {
        get => _highScore;
        set => _highScore = value;
    }

    /* --------------------------------------------------------------- */
    public void SetCheckpoint()
    {
        _waveCheckpoint = _currentWave;
    }
    
    private void SetStartWave(bool setFlag)
    {
        if (!setFlag)
        {
            _waveCheckpoint = 0;
            _ingameScoreMultiplier = _baseScoreMultiplier = 1;
        }
        else
        {
            _ingameScoreMultiplier = _baseScoreMultiplier;
        }
        _currentWave = _waveCheckpoint;
    }

    public void SetHealth(int health)
    {
        if (health >= MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
            return;
        }

        if (health <= MIN_HEALTH)
        {
            this.health = MIN_HEALTH;
            return;
        }

        this.health = health;
    }
    public void DecreaseHealth(int damage)
    {
        health -= damage;
        if (health <= MIN_HEALTH)
            health = MIN_HEALTH;
    }
    public int GetHealth()
    {
        return health;
    }
    
    public void SetHighscore(long score)
    {
        if(score <= highScore)
            return;

        highScore = score;
    }
    
    
    
    /* --------------------------------------------------------------- */

    public bool isAlive()
    {
        return health > MIN_HEALTH;
    }
    
    public void NextData()
    {
        _baseScoreMultiplier++;
        health += 20;
        if (health >= MAX_HEALTH)
            health = MAX_HEALTH;
        _ingameScoreMultiplier++;
        if (_currentWave != WaveManager.Instance.waveCount - 1)
            _currentWave++;
        else _currentWave = 0;
    }
    
}
