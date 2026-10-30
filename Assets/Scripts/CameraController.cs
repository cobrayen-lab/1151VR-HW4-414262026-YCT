using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset = new Vector3(0, 3, -8);

    void LateUpdate()
    {
        transform.position = Player.position + offset;
        transform.LookAt(Player);
    }
}
