using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsManeger : MonoBehaviour
{

    CatController[] catControllers;
    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random(1000);

        catControllers = new CatController[transform.childCount];

        foreach (Transform child in transform)
        {
            CatController cat = child.GetComponent<CatController>();
            float key_x = Mathf.Sign(r.Next(-1, 1));
            float key_y = Mathf.Sign(r.Next(-1, 1));
            double walkTime = r.NextDouble() * 4;
            cat.key_x = key_x;
            cat.key_y = key_y;
            if (walkTime < 0.3) walkTime = 0.3;
            cat.walkTime = walkTime;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
