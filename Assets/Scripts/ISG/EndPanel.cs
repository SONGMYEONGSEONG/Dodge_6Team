using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class EndPanel : MonoBehaviour
{
    //// �̱��� ������ ���� ���� �ν��Ͻ�
    //public static EndPanel instance;

    // ���� �г��� GameObject
    //public GameObject panelObject;
    // ����� ��ư
    public Button retryButton;
    // ���� �ð��� ǥ���� Text
    public TextMeshProUGUI finalTimeText;
    // ���� ������ ǥ���� Text
    public TextMeshProUGUI finalScoreText;
    // �ְ� ������ ǥ���� Text
    public TextMeshProUGUI bestScoreText;

    //// ���� ���� �ð��� ������ ����
    //private float startTime;

    //void Awake()
    //{
    //    // �̱��� ���� ����
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else if (instance != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //}


    void Start()
    {

        GameManager.Instance.OnEventGameOver += ShowPanel;
        // ���� �� ���� �г��� ��Ȱ��ȭ
        gameObject.SetActive(false);
        //// ����� ��ư�� ������ �߰�
        //retryButton.onClick.AddListener(RetryGame);
        // ���� ���� �ð� ���
        //startTime = Time.time;
    }

    // ���� �г��� ǥ���ϴ� public �޼���
    public void ShowPanel()
    {
        // �г� Ȱ��ȭ
        gameObject.SetActive(true);
        // ���� �Ͻ� ����
        //Time.timeScale = 0;
        // UI ������Ʈ
        UpdateUI();
    }

    // UI�� ������Ʈ�ϴ� private �޼���
    void UpdateUI()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sfx.Gameover);
        UpdateFinalTime();
        UpdateFinalScore();
        UpdateBestScore();
    }

    // ���� �ð��� ������Ʈ�ϴ� private �޼���
    void UpdateFinalTime()
    {
        finalTimeText.text = GameManager.Instance.CurGameTime.ToString("N2");
        //// ���� ���� �ð� ���
        //float playTime = Time.time - startTime;
        // �ð��� ��:�� �������� ��ȯ
        //string timeString = string.Format("{0:00}:{1:00}", Mathf.Floor(playTime / 60), playTime % 60);
        //finalTimeText.text = "Time: " + timeString;
    }

    // ���� ������ ������Ʈ�ϴ� private �޼���
    void UpdateFinalScore()
    {
        finalScoreText.text = GameManager.Instance.CurGameScore.ToString();
        //if (GameScore.instance != null)
        //{
        //    int finalScore = GameScore.instance.GetScore();
        //    finalScoreText.text = "Score: " + finalScore.ToString();
        //}
    }

    // �ְ� ������ ������Ʈ�ϴ� private �޼���
    void UpdateBestScore()
    {

        int currentScore = GameManager.Instance.CurGameScore;
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        bestScoreText.text = bestScore.ToString();

    }

    // ������ ������ϴ� private �޼���
    //void RetryGame()
    //{
    //    // ���� �ð��� ����ȭ
    //    Time.timeScale = 1;
    //    // ���� ���� �ٽ� �ε��Ͽ� ���� �����
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}