using UnityEngine;
using TMPro;

public class PassObstacle : MonoBehaviour
{
    public GameAudio gameAudio;
    public TMP_Text scoreText;

    private bool hasPassed = false;

    void Start()
    {
        // 畫面上先顯示目前的總分
        UpdateScoreUI(0); 
    }

    void OnTriggerEnter(Collider other)
    {
        // 當玩家穿過圓環時
        if (other.CompareTag("Player") && !hasPassed)
        {
            hasPassed = true;

            // 1. 取得撞到的玩家身上的 PlayerController 腳本
            PlayerController player = other.GetComponent<PlayerController>();
            
            if (player != null)
            {
                // 2. 叫玩家腳本自己把總分 +1
                player.AddScore(); 
                
                // 3. 把最新的總分更新到螢幕上
                UpdateScoreUI(player.currentScore); 
            }

            // 播放過關音效
            if (gameAudio != null)
            {
                gameAudio.PlayPass();
            }
        }
    }

    // 抽出一個統一更新 UI 文字的防呆功能
    void UpdateScoreUI(int currentTotalScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentTotalScore;
        }
    }
}
