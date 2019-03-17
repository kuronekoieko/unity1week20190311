using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsManeger : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip[] catCrys;
    int i = 0;

    System.Random r = new System.Random(1000);
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        catCrys = new AudioClip[transform.childCount];

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
            // cat.catCry = catCrys[i];
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
