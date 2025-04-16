using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;

    private float elapsedTime = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // Ÿ�̸Ӹ� �Ͻ�����
    public void PauseTimer()
    {
        isRunning = false;
    }

    // Ÿ�̸Ӹ� �ٽ� ����
    public void ResumeTimer()
    {
        isRunning = true;
    }

    // Ÿ�̸Ӹ� �ʱ�ȭ
    public void ResetTimer()
    {
        elapsedTime = 0f;
        timerText.text = "00:00";
    }
}
