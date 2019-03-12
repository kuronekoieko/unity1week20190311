using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class CatController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCol;
    [NonSerialized] public bool isChase;

    //[SerializeField] PlayerController playerController;
    [NonSerialized] public GameObject targetObj;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        //targetObj = playerController.gameObject;
        //追従ロジック
        if (isChase) ChaseTarget(targetObj.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        boxCol.enabled = !isChase;
        //画像の左右反転
        SetLocalScale();

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
