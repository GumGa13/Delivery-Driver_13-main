using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameEndUI;
    public Image fadePanel;
    public TextMeshProUGUI inGameTimeText;
    public TextMeshProUGUI finalTimeText;
    public Button retryButton;

    private float playTime;
    private bool isGameEnded = false;

    public int totalChickenCount;
    private int deliveredChickenCount = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // 게임 시작 시 UI 초기화
        gameEndUI.SetActive(false);
        fadePanel.color = new Color(0, 0, 0, 0);

        // 치킨 개수 파악
        totalChickenCount = GameObject.FindGameObjectsWithTag("Chicken").Length;

        // 버튼 이벤트 등록
        retryButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (!isGameEnded)
        {
            playTime += Time.deltaTime;
            inGameTimeText.text = $"Time: {playTime:F2}s";
        }
    }

    public void RegisterChicken()
    {
        totalChickenCount++;
    }

    public void ChickenDelivered()
    {
        deliveredChickenCount++;

        if (deliveredChickenCount >= totalChickenCount)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        isGameEnded = true;
        StartCoroutine(FadeOutAndShowResult());
    }

    System.Collections.IEnumerator FadeOutAndShowResult()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 2f; // 빠르게 어두워짐
            fadePanel.color = new Color(0, 0, 0, t);
            yield return null;
        }

        gameEndUI.SetActive(true);
        finalTimeText.text = $"Play Time: {playTime:F2}s";
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
