using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class PlayerController : MonoBehaviour
{

    [NonSerialized] public Rigidbody2D rb;
    int key_x = 0;
    int key_y = 0;

    //int Variable.catCount;

    [SerializeField] CatController neko_0;
    [SerializeField] CatController neko_1;
    [SerializeField] CatController neko_2;
    [SerializeField] CatController neko_3;
    [SerializeField] CatController neko_4;
    [SerializeField] CatController neko_5;
    [SerializeField] CatController neko_6;
    [SerializeField] CatController neko_7;

    CatController[] nekos;

    //CatController[] catsStock;

    List<CatController> catList;

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

        catList = new List<CatController>();
        //catsStock = new CatController[Variable.catsCount * 8];
        //CatsGenerator();


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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Variable.isTimeUp) return;

        if (other.gameObject.tag.Equals("cat"))
        {
            Debug.Log("ねこ");
            CatAddList(other.gameObject);
        }
        if (other.gameObject.tag.Equals("water"))
        {
            Debug.Log("水");
            CatRemoveList();
        }

    }



    // Update is called once per frame
    void Update()
    {

        key_x = 0;
        key_y = 0;

        if (Variable.isTimeUp) return;

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

    void CatRemoveList()
    {
        //if (Variable.catCount == 0) return;

        while (Variable.catCount > 0)
        {
            Variable.catCount--;
            catList[Variable.catCount].isChase = false;
            catList.RemoveAt(Variable.catCount);
        }

    }

    void CatAddList(GameObject cat)
    {
        catList.Add(cat.GetComponent<CatController>());
        // cat.name = Variable.catCount.ToString();

        if (Variable.catCount == 0)
        {
            catList[Variable.catCount].targetObj = gameObject;

        }
        else
        {
            catList[Variable.catCount].targetObj = catList[Variable.catCount - 1].gameObject;
        }
        catList[Variable.catCount].isChase = true;
        Variable.catCount++;
    }


}
