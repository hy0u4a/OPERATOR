using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    SpriteRenderer characterRenderer;
    SpriteRenderer bulletRenderer;
    Rigidbody2D rigid;


    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    void Awake()
    {
        GameObject character = GameObject.Find("Character");
        characterRenderer = character.GetComponent<SpriteRenderer>();
        bulletRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.right, 1, LayerMask.GetMask("Enemy"));
        if (rayHit.collider != null)
        {
            DestroyBullet();
        }
        if (characterRenderer.flipX == false)
        {
            bulletRenderer.flipX = false;
            rigid.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
        else if (characterRenderer.flipX == true)
        {
            bulletRenderer.flipX = true;
            rigid.AddForce(Vector2.right * -1 * speed, ForceMode2D.Impulse);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
