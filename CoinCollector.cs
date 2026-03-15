using UnityEngine;
using TMPro; // 使用 TextMeshPro 必不可少的命名空间

public class CoinCollector : MonoBehaviour
{
    // 使用 static 关键字，确保金币数量在全局只有一份，且方便被 DeathHandler 脚本重置
    public static int coinCount = 0;

    [Header("UI 设置")]
    // 在 Inspector 面板中把 Hierarchy 里的 Text (TMP) 拖到这个位置
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // 游戏开始时，确保 UI 显示的是当前金币数（通常是 0）
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检查碰撞到的物体是否带有 "Coin" 标签
        // 这样可以确保复制出来的金币只要带标签都能被识别
        if (collision.CompareTag("Coin"))
        {
            // 1. 增加计数
            coinCount++;

            // 2. 更新屏幕上的文字显示
            UpdateScoreText();

            // 3. 在控制台打印，方便调试
            Debug.Log("当前金币总数: " + coinCount);

            // 4. 销毁金币物体
            Destroy(collision.gameObject);
        }
    }

    // 更新 UI 文字的逻辑
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + coinCount.ToString();
        }
    }

    // 静态方法：供 DeathHandler.cs 在玩家死亡重置场景时调用
    public static void ResetCoins()
    {
        coinCount = 0;
    }
}