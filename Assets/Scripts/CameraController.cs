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

    // Update is called once per frame
    void Update()
    {
        float x = playerController.gameObject.transform.position.x;
        float y = playerController.gameObject.transform.position.y;
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
