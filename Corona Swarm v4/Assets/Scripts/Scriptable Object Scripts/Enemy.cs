using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemy Stats")]
public class Enemy : Projectile
{
    private Rigidbody2D _rigidbody2D;
    public bool isMini;
    public void InitializeComponents(GameObject prefab)
    {
        projectileModel = prefab;
        _rigidbody2D = projectileModel.GetComponent<Rigidbody2D>();
        if (isMini)
        {
            MakeSmaller();
        }
    }

    public override void Move(Transform transform, Transform target)
    {
        transform.position += (target.position - transform.position).normalized * (speed * Time.deltaTime);
        //Rigidbody2D.(Player.Instance.transform.position * speed * Time.deltaTime);
    }

    public override void Collide(GameObject collidingObject)
    {
        collidingObject.SetActive(false);
    }

    private void MakeSmaller()
    {
        var transformLocalScale = projectileModel.transform.localScale;
        transformLocalScale.x -= 0.10f;
        transformLocalScale.y -= 0.10f;

    }
}
