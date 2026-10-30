using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameAudio gameAudio;

    // 當玩家撞到空中的障礙物時
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 僅播放普通撞擊音效，不影響遊戲進行
            if (gameAudio != null)
            {
                gameAudio.PlayCollision(); 
            }

            Debug.Log("飛機撞到障礙物（彈開）");
        }
    }
}
