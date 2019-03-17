using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class CatController : MonoBehaviour
{
    [NonSerialized] public CatState catState = CatState.TOUCH_WATER;
    [NonSerialized] public GameObject targetObj;
    [NonSerialized] public double walkTime;
    [NonSerialized] public float key_x;
    [NonSerialized] public float key_y;
    [NonSerialized] public AudioClip catCry;
    Rigidbody2D rb;
    BoxCollider2D boxCol;
    float timer;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
    }
    private void FixedUpdate()
    {
        switch (catState)
        {
            case CatState.TOUCH_WATER:
                boxCol.enabled = true;
                catState = CatState.RELEASE;
                break;
            case CatState.RELEASE:
                AutoMove();
                break;
            case CatState.TOUCH_PLAYER:
                boxCol.enabled = false;
                audioSource.Play();
                catState = CatState.CHASE;
                break;
            case CatState.CHASE:
                ChaseTarget(targetObj.transform.position);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //画像の左右反転
        SetLocalScale();

    }

    void AutoMove()
    {
        timer += Time.fixedDeltaTime;

        if (timer < walkTime)
        {
            rb.velocity = new Vector2(key_x, key_y);
        }
        else
        {
            key_x *= -1;
            key_y *= -1;
            timer = 0;
        }

    }

    void SetLocalScale()
    {
        //float x = 0;
        float x = -Mathf.Sign(rb.velocity.x);
        if (rb.velocity.x == 0) x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;
        transform.localScale = new Vector3(x, y, z);
    }


    void ChaseTarget(Vector3 target)
    {

        Vector2 vec = target - transform.position;
        if (vec.magnitude < 1.5f)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        rb.velocity = vec.normalized * Variable.walkSpeed;
    }
}
