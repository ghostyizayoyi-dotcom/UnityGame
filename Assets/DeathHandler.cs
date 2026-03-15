using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathHandler : MonoBehaviour
{
    public Animator animator;
    public GameObject deathPanel; // 拖入 DeathPanel
    public GameObject startPanel; // 拖入 StartPanel

    void Start()
    {
        // 游戏刚开始时，先冻结时间，等玩家点“开始”
        Time.timeScale = 0;
        if (deathPanel) deathPanel.SetActive(false);
        if (startPanel) startPanel.SetActive(true);
    }

    // 给“开始按钮”绑定的函数
    public void StartGame()
    {
        Time.timeScale = 1; // 恢复时间
        startPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "DeathZone")
        {
            StartCoroutine(DieSequence());
        }
    }

    IEnumerator DieSequence()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSecondsRealtime(1.0f); // 死亡动画播完

        // 显示死亡面板，停止游戏时间
        deathPanel.SetActive(true);
        Time.timeScale = 0;
    }

    // 给“重新开始按钮”绑定的函数
    public void RestartGame()
    {
        Time.timeScale = 1; // 恢复时间
        CoinCollector.ResetCoins(); // 重置金币
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}