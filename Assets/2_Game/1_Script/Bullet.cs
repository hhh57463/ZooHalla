using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fBulletDmg;

    float fBulletSpeed;
    float fBulletDegree;


    // Start is called before the first frame update
    void Start()
    {
        if (!SGameMng.I.TargetEnemyTr.Equals(null))
        {
            float dy = SGameMng.I.TargetEnemyTr.position.y - transform.position.y;
            float dx = SGameMng.I.TargetEnemyTr.position.x - transform.position.x;
            fBulletDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(fBulletDegree - 90f, Vector3.forward);
        }
        fBulletDmg = 5.0f;
        fBulletSpeed = 15.0f;
        StartCoroutine(DestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }

    void BulletMove()
    {
        transform.Translate(Vector2.up * fBulletSpeed * Time.deltaTime);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Monster"))
        {
            Monster HitMonsterSc = col.GetComponent<Monster>();
            HitMonsterSc.fMonsterHp -= fBulletDmg;
            Destroy(gameObject);
        }
        if (col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

}
