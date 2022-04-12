using System.Collections;
using UnityEngine;
using DG.Tweening;
public class UIManager : MonoSingleton<UIManager>
{
    
    public Color deathColor;
    
    
    [SerializeField] private GameObject backgroundObject;
    [SerializeField] private float transitionDuration;
    private SpriteRenderer _background;


    private Transform _playerTransform;
    private GameObject _mutatedCell;


    private Tween _backgroundTransitionTween;
    private Tween _mutationTransitionTween;
    
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
        ActivateDeathBackground();
        ActivateMutation(enemyHit);
        Debug.Log(brokenRecord);
        if (!brokenRecord)
        {
            
        }
        else
        {
            StartCoroutine(ActivateHighscoreScreen(highScore));
        }
        //StartCoroutine(ActivateAwakening());
        
    }
    

    private void ActivateDeathBackground()
    {
        _backgroundTransitionTween = _background.DOColor(deathColor, transitionDuration).SetAutoKill(false);
        _backgroundTransitionTween.Play();
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
        yield return new WaitForSeconds(transitionDuration);
        _backgroundTransitionTween = _background.DOColor(Color.white, transitionDuration * 2f).SetAutoKill(false);
        _backgroundTransitionTween.Play();
        Debug.Log("YOUR NEW HIGHSCORE: " + highscore);
    }

    private void InitializeTweens()
    {
        //_backgroundTransitionTween = _background.DOColor(deathColor, transitionDuration);
        //_mutationTransitionTween = 
    }
}
