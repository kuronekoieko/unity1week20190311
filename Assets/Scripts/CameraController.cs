using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
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



        float key_x = Mathf.Sign(player_x - camera_x);
        if (Mathf.Abs(player_x - camera_x) > Variable.cam_range_x)
        {
            camera_x = player_x - Variable.cam_range_x * key_x;
        }

        float key_y = Mathf.Sign(player_y - camera_y);
        if (Mathf.Abs(player_y - camera_y) > Variable.cam_range_y)
        {
            camera_y = player_y - Variable.cam_range_y * key_y;
        }

        transform.position = new Vector3(camera_x, camera_y, transform.position.z);
    }
}
