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
    bool rotation = true;


    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    void Awake()
    {
        GameObject character = GameObject.Find("Character");
        characterRenderer = character.GetComponent<SpriteRenderer>();
        bulletRenderer = GetComponent<SpriteRenderer>();
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
                transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else if (characterRenderer.flipX == true)
        {
                bulletRenderer.flipX = true;
                transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
