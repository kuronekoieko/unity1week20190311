using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    int key_x = 0;
    int key_y = 0;

    [SerializeField] CatController neko_0;
    [SerializeField] CatController neko_1;
    [SerializeField] CatController neko_2;
    [SerializeField] CatController neko_3;
    [SerializeField] CatController neko_4;
    [SerializeField] CatController neko_5;
    [SerializeField] CatController neko_6;
    [SerializeField] CatController neko_7;

    CatController[] nekos;

    CatController[] cats_0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        nekos = new CatController[8];
        nekos[0] = neko_0;
        nekos[1] = neko_1;
        nekos[2] = neko_2;
        nekos[3] = neko_3;
        nekos[4] = neko_4;
        nekos[5] = neko_5;
        nekos[6] = neko_6;
        nekos[7] = neko_7;

        cats_0 = new CatController[Variable.catsCount * 8];
        CatsGenerator();


    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(key_x, key_y).normalized * Variable.walkSpeed;
        //Debug.Log(rb.velocity);
        //float x = key_x * Mathf.Abs(transform.localScale.x);
        float x = key_x;
        if (key_x == 0) x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;
        transform.localScale = new Vector3(x, y, z);


    }

    // Update is called once per frame
    void Update()
    {
        key_x = 0;
        key_y = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            key_y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            key_y = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key_x = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key_x = -1;
        }
    }

    void CatsGenerator()
    {


        for (int i = 0; i < Variable.catsCount; i++)
        {

            GameObject cat = Instantiate(nekos[i].gameObject, transform.position, Quaternion.identity);
            cat.name = i.ToString();
            cats_0[i] = cat.GetComponent<CatController>();

            //一匹目はプレイヤーにする
            if (i == 0)
            {
                cats_0[i].targetObj = gameObject;
            }
            else
            {
                cats_0[i].targetObj = cats_0[i - 1].gameObject;
            }
        }


    }

}
