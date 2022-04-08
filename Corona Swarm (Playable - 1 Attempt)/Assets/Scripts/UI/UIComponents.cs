using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UI Components", menuName = "UI Component Data")]
public class UIComponents : ScriptableObject
{
    [Header("In Game Data")]
    [SerializeField] private Text _waveIndicator;
    [SerializeField] private Text _scoreText;
    
    [Header("Player Data")]
    [SerializeField] private Image _playerHeart;
    [SerializeField] private Text _playerHealth;

    public Text WaveIndicator
    {
        get => _waveIndicator;
        set => _waveIndicator = value;
    }

    public Text ScoreText
    {
        get => _scoreText;
        set => _scoreText = value;
    }

    public Image PlayerHeart
    {
        get => _playerHeart;
        set => _playerHeart = value;
    }

    public Text PlayerHealth
    {
        get => _playerHealth;
        set => _playerHealth = value;
    }
}
