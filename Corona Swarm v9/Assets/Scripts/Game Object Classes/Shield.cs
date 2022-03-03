using UnityEngine;

public class Shield : MonoSingleton<Shield>
{
    private int killCount;
    public int comboTrigger;
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Enemy")) return;
        
        if (col.gameObject.TryGetComponent(out Enemy enemyObject))
        {
            killCount++;
            Player.Instance.AddKillScore(enemyObject.score);
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
