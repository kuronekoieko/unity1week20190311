using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] PlayerController playerController;



    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float camera_x = transform.position.x;
        float camera_y = transform.position.y;

        float player_x = playerController.gameObject.transform.position.x;
        float player_y = playerController.gameObject.transform.position.y;

        float range_x = 3.0f;
        float range_y = 0.5f;

        float key_x = Mathf.Sign(player_x - camera_x);
        if (Mathf.Abs(player_x - camera_x) > range_x)
        {
            camera_x = player_x - range_x * key_x;
        }

        float key_y = Mathf.Sign(player_y - camera_y);
        if (Mathf.Abs(player_y - camera_y) > range_y)
        {
            camera_y = player_y - range_y * key_y;
        }

        transform.position = new Vector3(camera_x, camera_y, transform.position.z);
    }
}
