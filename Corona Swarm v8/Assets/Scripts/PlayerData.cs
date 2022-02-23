using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    private long highScore;
    [Range(0, 3)] [SerializeField] private int comboCount = 0;
    [Range(1, 200)] private int scoreMultiplier = 1;
    [Range(0, 100)] [SerializeField] private int health;
    [SerializeField] private Texture protectionTexture;
    
    // Buraya bir powerup stack'i falan da koy.
    public bool hasProtection;

    public void SetHealth(int health)
    {
        if (health >= 100)
        {
            this.health = 100;
            return;
        }

        if (health <= 0)
        {
            this.health = 0;
            return;
        }

        this.health = health;
    }
    public int GetHealth()
    {
        return health;
    }
    
    public void SetHighScore(long score)
    {
        if(score < highScore)
            return;

        highScore = score;
    }
    
    public long GetHighScore()
    {
        return highScore;
    }
    
    public int GetComboCount()
    {
        return comboCount;
    }
    
    public void IncreaseMultipler()
    {
        if (comboCount >= 3)
        {
            comboCount = 5;
        }
        else
        {
            comboCount++;
        }        
        
        scoreMultiplier *= (int) Mathf.Pow(2, comboCount);

        if (scoreMultiplier >= 200)
            scoreMultiplier = 200;

    }
    public void DecreaseMultipler()
    {
        if (comboCount <= 0)
        {
            comboCount = 0;
        }
        else
        {
            comboCount--;
        }        
        
        scoreMultiplier /= (int) Mathf.Pow(2, comboCount);

        if (scoreMultiplier <= 1)
            scoreMultiplier = 1;
    }
    // combo yaptıktan sonra modifierı 1 arttıracağın bir fonk koy.
    // damage yedikten sonra modifierı 1 azaltıcağın bir fonk koy.
    
}
