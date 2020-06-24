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
    Animator animator;

    void Start()
    {
        
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                animator.SetBool("IsAttacking", true);
                Instantiate(bullet, pos.position, transform.rotation);
            }
            else
            {
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    animator.SetBool("IsAttacking", false);
                }
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}
