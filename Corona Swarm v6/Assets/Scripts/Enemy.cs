using DG.Tweening;
using UnityEngine;

public class Enemy : Projectile
{
    [Range(0, 1)]
    public float miniProbablity;
    private Tween moveTween;
    
    private void Awake()
    {
        //InitializeComponents();
    }

    private void Start()
    {
        InitializeComponents();
        //if (gameObject == null) return;
        Move();
    }
    

    private void InitializeComponents()
    {
        if (Utility.GetRandomness(miniProbablity))
        {
            MakeSmaller();
        }
        moveTween = transform.DOMove(Player.Instance.transform.position, duration).SetAutoKill(false);

    }

    public override void Move()
    {
        moveTween.Play();
        //transform.position += (target.position - transform.position).normalized * (speed * Time.deltaTime);
        //Rigidbody2D.(Player.Instance.transform.position * speed * Time.deltaTime);

    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Shield"))
        {
            Collide();
        }
    }

    public override void Collide()
    {
        //Instantiate(onDestroyParticles);
        //onDestroyParticles.transform.parent = transform;
        //onDestroyParticles.Play();
        gameObject.SetActive(false);
    }

    private void MakeSmaller()
    {
        transform.localScale = new Vector2(0.10f, 0.10f);

    }
}
