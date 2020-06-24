using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPos : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform transform;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject character = GameObject.Find("Character");
        spriteRenderer = character.GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer.flipX == true)
        {
            transform.localPosition = new Vector3(-0.1f, 0.06f, 0);
        }
        else
        {
            transform.localPosition = new Vector3(0.1f, 0.06f, 0);
        }
    }
}
