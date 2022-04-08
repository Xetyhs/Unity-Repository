using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    
    public Color deathColor;
    
    
    [SerializeField] private GameObject backgroundObject;
    [SerializeField] private float transitionDuration;
    private SpriteRenderer _background;


    private Transform _playerTransform;
    private GameObject _mutatedCell;


    private Tween _backgroundTransitionTween;
    private Tween _textTransitionTween;
    private Tween _mutationTransitionTween;
    private Color _prevBackgroundColor;
    private Text _prevLevelText;


    [SerializeField] private Text _healthText;
    [SerializeField] private Image _healthImage;
    [SerializeField] private Text _levelText;

    [SerializeField] private UIComponents componentsData;


    [SerializeField] private Color[] heartDisplayColors = new Color[4];

    // Start is called before the first frame update

    private void Awake()
    {
        _playerTransform = Player.Instance.transform;
        _background = backgroundObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DeathAnimation(GameObject enemyHit, bool brokenRecord, long highScore)
    {
        //SpriteRenderer killerSprite = enemyHit.GetComponent<SpriteRenderer>();
        GameOverScreen();
        ActivateMutation(enemyHit);
        Debug.Log(brokenRecord);
        if (brokenRecord)
        {
            StartCoroutine(ActivateHighscoreScreen(highScore));
        }
        
        StartCoroutine(ReturnToMainScreen());
    }
    

    private void GameOverScreen()
    {
        _prevBackgroundColor = _background.color;
        _backgroundTransitionTween = _background.DOColor(deathColor, transitionDuration).SetAutoKill(false);
        _backgroundTransitionTween.Play();

        _prevLevelText = _levelText;
        _levelText.fontStyle = FontStyle.Bold;
        _levelText.fontSize = 36;
        _levelText.text = "GAME   OVER.";
        _textTransitionTween = _levelText.DOColor(Color.black, transitionDuration).SetAutoKill(false);
        _textTransitionTween.Play();
        
    }


    private void ActivateMutation(GameObject enemyHit)
    {
        _mutatedCell = Instantiate(enemyHit, _playerTransform.position, _playerTransform.rotation);
        _mutatedCell.GetComponent<Enemy>().enabled = false;
        _mutatedCell.SetActive(true);
        _mutatedCell.transform.localScale = _playerTransform.localScale;
        _mutatedCell.GetComponent<SpriteRenderer>().color = Color.black;
    }

    private IEnumerator ActivateHighscoreScreen(long highscore)
    {
        yield return new WaitForSeconds(transitionDuration + 2f);
        
        
        _backgroundTransitionTween = _background.DOColor(Color.white, transitionDuration * 2f).SetAutoKill(false);
        _backgroundTransitionTween.Play();
        
        
        _levelText.fontSize = 20;
        _levelText.text = "YOUR NEW HIGHSCORE: " + highscore;
        _textTransitionTween = _levelText.DOColor(Color.white, transitionDuration).SetAutoKill(false);
        _textTransitionTween.Play();

        yield return new WaitForSeconds(3f);
        
    }

    private IEnumerator ReturnToMainScreen()
    {
        yield return new WaitForSeconds(transitionDuration + 5f);

        _backgroundTransitionTween = _background.DOColor(_prevBackgroundColor, transitionDuration * 2f).SetAutoKill(false);
        _backgroundTransitionTween.Play();
        
        _levelText = _prevLevelText;
        //MenuUI.Instance.gameObject.SetActive(true);

    }
    
    
    private void InitializeTweens()
    {
        //_backgroundTransitionTween = _background.DOColor(deathColor, transitionDuration);
        //_mutationTransitionTween = 
    }

    
    
    public void UpdateUI()
    {
        var playerHealth = Player.Instance.GetHealth();
        _healthText.text = ": " + playerHealth;

        if (playerHealth >= 75 && playerHealth < 100)
        {
            ColorTransition(heartDisplayColors[0]);

        } else if (playerHealth >= 50 && playerHealth < 75)
        {
            ColorTransition(heartDisplayColors[1]);
        } else if (playerHealth >= 25 && playerHealth < 50)
        {
            ColorTransition(heartDisplayColors[2]);
            
        } else if (playerHealth > 0 && playerHealth < 25)
        {
            ColorTransition(heartDisplayColors[3]);
        }
    }

    public void NextLevelUI()
    {
        // 129 çalışmıyor.
        _levelText.text = "LEVEL " + (Player.Instance.GetCurrentWave() + 1).ToString();
        UpdateUI();
    }

    private void ColorTransition(Color transitionTarget)
    {
        if(_healthImage.color == transitionTarget || _healthText.color == transitionTarget)
            return;
        
        _healthImage.DOColor(transitionTarget, transitionDuration).SetAutoKill(false);
        _healthText.DOColor(transitionTarget, transitionDuration).SetAutoKill(false);

    }
}
