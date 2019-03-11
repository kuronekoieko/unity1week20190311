using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 vec = playerController.gameObject.transform.position - transform.position;
        if (vec.magnitude < 1.5f)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        rb.velocity = vec.normalized * playerController.walkSpeed;
    }
    // Update is called once per frame
    void Update()
    {


        //float x = 0;
        float x = -Mathf.Sign(rb.velocity.x);
        if (rb.velocity.x == 0) x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;
        transform.localScale = new Vector3(x, y, z);
    }
}
