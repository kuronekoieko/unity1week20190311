using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject topRightPos;
    [SerializeField] GameObject bottomLeftPos;
    private Camera _mainCamera;

    float widthHalf;
    float heightHalf;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = GetComponent<Camera>();
        widthHalf = getScreenBottomRight().x - transform.position.x;
        heightHalf = getScreenTopLeft().y - transform.position.y;
    }

    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(CameraX(), CameraY(), transform.position.z);
    }

    float CameraX()
    {
        float camera_x = transform.position.x;
        float player_x = playerController.gameObject.transform.position.x;

        float max_x = topRightPos.transform.position.x;
        float min_x = bottomLeftPos.transform.position.x;

        float key_x = Mathf.Sign(player_x - camera_x);
        if (Mathf.Abs(player_x - camera_x) > Variable.cam_range_x)
        {
            camera_x = player_x - Variable.cam_range_x * key_x;

        }

        camera_x = Mathf.Clamp(camera_x, min_x + widthHalf, max_x - widthHalf);
        return camera_x;
    }


    float CameraY()
    {
        float camera_y = transform.position.y;
        float player_y = playerController.gameObject.transform.position.y;
        float max_y = topRightPos.transform.position.y;
        float min_y = bottomLeftPos.transform.position.y;

        float key_y = Mathf.Sign(player_y - camera_y);
        if (Mathf.Abs(player_y - camera_y) > Variable.cam_range_y)
        {
            camera_y = player_y - Variable.cam_range_y * key_y;
        }

        camera_y = Mathf.Clamp(camera_y, min_y + heightHalf, max_y - heightHalf);
        return camera_y;
    }

    private Vector3 getScreenTopLeft()
    {
        // 画面の左上を取得
        Vector3 topLeft = _mainCamera.ScreenToWorldPoint(Vector3.zero);
        // 上下反転させる
        topLeft.Scale(new Vector3(1f, -1f, 1f));
        return topLeft;
    }

    private Vector3 getScreenBottomRight()
    {
        // 画面の右下を取得
        Vector3 bottomRight = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        // 上下反転させる
        bottomRight.Scale(new Vector3(1f, -1f, 1f));
        return bottomRight;
    }
}
