using System.Collections;
using UnityEngine;

public class Player : MonoSingleton<Player>
{

    [SerializeField] private PlayerData _playerData;
    private long score;
    
    public PlayerData PlayerData => _playerData;
    private GameObject protectionShield;
    
    // PlayerData dangerous usage. Find a better solution for this.
    private void Awake()
    {
        score = 0;
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

    

    // Function to get protection for seconds secs.
    
    /**
     *
     * Works Fine.
     */
    
    /**
     * PlayerData has to be used here. So no problem.
     */
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
        // Heal particle çalışsın.
        _playerData.SetHealth(_playerData.GetHealth() + hp);
        yield return GetProtection(1.5f);
    }

    // Bunu solid'e uyarla.
    public void AddKillScore(int score)
    {
        this.score += score * _playerData.IngameScoreMultiplier + (Shield.Instance.GetKillCount() - Shield.Instance.comboTrigger);
    }

    // Takes damage, and gets protection for 3 secs.
    
    /**
     * PlayerData has to be used here. So no problem.
     */
    private IEnumerator TakeDamage(int damage)
    {
        if (_playerData.hasProtection)
            yield break;
        
        _playerData.TakeDamage(damage);
        
        if (!_playerData.isAlive())
        { 
            DeathTrigger();
        }
        yield return GetProtection();
    }
    
    private void DeathTrigger()
    {
        // When PLAYER dies, its current wave will be saved as checkpoint on PlayerData.
        // So, if player wants to restart, it can start from the latest wave.
        
        _playerData.SetHighscore(score);
        _playerData.SetCheckpoint();
        gameObject.SetActive(false);
        // DeathAnimation()
        
    }

    
    public void OnTriggerEnter2D(Collider2D col)
    {
        //if (!col.CompareTag("Enemy") || !col.CompareTag("Heal Orb")) return;

        if (col.gameObject.TryGetComponent(out Enemy enemyObject))
        {
            StartCoroutine(TakeDamage(enemyObject.damage));
        }

        if (col.gameObject.TryGetComponent(out HealOrb healOrbObject))
        {
            StartCoroutine(Heal(healOrbObject.healAmount));
        }

        if (col.CompareTag("Protection Orb"))
        {
            StartCoroutine(GetProtection());
        }
        
    }
}
