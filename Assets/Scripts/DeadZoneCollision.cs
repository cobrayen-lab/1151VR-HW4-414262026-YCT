using UnityEngine;
using TMPro;

public class DeadZoneCollision : MonoBehaviour
{
    [Header("音效與UI綁定")]
    public GameAudio gameAudio;       
    public TMP_Text gameOverText; 

    private bool isGameOver = false;

    void Start()
    {
        if (gameOverText != null)
        {
            // 遊戲一開始直接將文字置中，並清空內容
            gameOverText.alignment = TextAlignmentOptions.Center;
            gameOverText.text = ""; 
        }
        
        Time.timeScale = 1f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isGameOver)
        {
            isGameOver = true;

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.enabled = false;
            }

            if (gameOverText != null && player != null)
            {
                // 確保遊戲結束顯現時也是完美置中
                gameOverText.alignment = TextAlignmentOptions.Center;
                gameOverText.text = "Game Over\nScore: " + player.currentScore;
            }

            if (gameAudio != null)
            {
                gameAudio.StopFlyingSound();
                gameAudio.PlayCollision(); 
            }

            Time.timeScale = 0f;
        }
    }
}
