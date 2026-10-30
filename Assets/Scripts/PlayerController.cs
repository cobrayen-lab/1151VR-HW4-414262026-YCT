using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float moveSpeed = 5f;
    public float touchSensitivity = 0.01f;

    // 【新增】：讓玩家自己來記錄整場遊戲的總分數
    [HideInInspector] public int currentScore = 0; 

    void Update()
    {
        transform.Translate(-transform.forward * speed * Time.deltaTime, Space.World);

        float x = 0f; float y = 0f;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            x = Input.GetAxis("Horizontal"); y = Input.GetAxis("Vertical");
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                x = touch.deltaPosition.x * touchSensitivity;
                y = touch.deltaPosition.y * touchSensitivity;
            }
        }
        Vector3 move = new Vector3(x, y, 0f);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }

    // 【新增】：提供一個可以讓圓環呼叫的加分功能
    public void AddScore()
    {
        currentScore++;
    }
}
