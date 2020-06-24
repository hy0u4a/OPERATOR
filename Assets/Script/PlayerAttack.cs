using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;
    public float delay;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    void Start()
    {
        
    }

    void Awake()
    {
        GameObject character = GameObject.Find("Character");
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = character.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                animator.SetBool("IsAttacking", true);
               // animator.SetBool("IsJumpAttacking", true);
                delay = cooltime;
                Instantiate(bullet, pos.position, transform.rotation);
            }
            else
            {
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    animator.SetBool("IsJumpAttacking", false);
                    animator.SetBool("IsAttacking", false);
                }
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}
