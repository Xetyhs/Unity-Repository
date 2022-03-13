using UnityEngine;

public class Shield : MonoSingleton<Shield>
{
    private int killCount;
    [SerializeField] private int _comboTrigger;

    public int comboTrigger => _comboTrigger;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Enemy enemyObject))
        {
            killCount++;
            Player.Instance.AddKillScore(enemyObject.score);
        }
        
        if (col.gameObject.TryGetComponent(out HealOrb healOrbObject))
        {
            StartCoroutine(Player.Instance.Heal(healOrbObject.healAmount));
        }

        if (col.CompareTag("Protection Orb"))
        {
            StartCoroutine(Player.Instance.GetProtection());
        }

        if (col.CompareTag("Wipe Orb"))
        {
            Player.Instance.WipeEnemies();
        }
    }

    public int GetKillCount()
    {
        return killCount;
    }

    public void SetKillCount(int killCount)
    {
        this.killCount = killCount;
    }
}
