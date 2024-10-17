using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class EndPanel : MonoBehaviour
{
    // �̱��� ������ ���� ���� �ν��Ͻ�
    public static EndPanel instance;

    // ���� �г��� GameObject
    public GameObject panelObject;
    // ����� ��ư
    public Button retryButton;
    // ���� �ð��� ǥ���� Text
    public Text finalTimeText;
    // ���� ������ ǥ���� Text
    public Text finalScoreText;
    // �ְ� ������ ǥ���� Text
    public Text bestScoreText;

    // ���� ���� �ð��� ������ ����
    private float startTime;

    void Awake()
    {
        // �̱��� ���� ����
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ���� �� ���� �г��� ��Ȱ��ȭ
        panelObject.SetActive(false);
        // ����� ��ư�� ������ �߰�
        retryButton.onClick.AddListener(RetryGame);
        // ���� ���� �ð� ���
        startTime = Time.time;
    }

    // ���� �г��� ǥ���ϴ� public �޼���
    public void ShowPanel()
    {
        // �г� Ȱ��ȭ
        panelObject.SetActive(true);
        // ���� �Ͻ� ����
        Time.timeScale = 0;
        // UI ������Ʈ
        UpdateUI();
    }

    // UI�� ������Ʈ�ϴ� private �޼���
    void UpdateUI()
    {
        UpdateFinalTime();
        UpdateFinalScore();
        UpdateBestScore();
    }

    // ���� �ð��� ������Ʈ�ϴ� private �޼���
    void UpdateFinalTime()
    {
        // ���� ���� �ð� ���
        float playTime = Time.time - startTime;
        // �ð��� ��:�� �������� ��ȯ
        string timeString = string.Format("{0:00}:{1:00}", Mathf.Floor(playTime / 60), playTime % 60);
        finalTimeText.text = "Time: " + timeString;
    }

    // ���� ������ ������Ʈ�ϴ� private �޼���
    void UpdateFinalScore()
    {
        if (GameScore.instance != null)
        {
            int finalScore = GameScore.instance.GetScore();
            finalScoreText.text = "Score: " + finalScore.ToString();
        }
    }

    // �ְ� ������ ������Ʈ�ϴ� private �޼���
    void UpdateBestScore()
    {
        if (GameScore.instance != null)
        {
            int currentScore = GameScore.instance.GetScore();
            int bestScore = PlayerPrefs.GetInt("BestScore", 0);

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }

            bestScoreText.text = "Best Score: " + bestScore.ToString();
        }
    }

    // ������ ������ϴ� private �޼���
    void RetryGame()
    {
        // ���� �ð��� ����ȭ
        Time.timeScale = 1;
        // ���� ���� �ٽ� �ε��Ͽ� ���� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}