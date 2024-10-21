using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class EndPanel : MonoBehaviour
{
    //// 싱글톤 패턴을 위한 정적 인스턴스
    //public static EndPanel instance;

    // 엔드 패널의 GameObject
    //public GameObject panelObject;
    // 재시작 버튼
    public Button retryButton;
    // 최종 시간을 표시할 Text
    public TextMeshProUGUI finalTimeText;
    // 최종 점수를 표시할 Text
    public TextMeshProUGUI finalScoreText;
    // 최고 점수를 표시할 Text
    public TextMeshProUGUI bestScoreText;

    //// 게임 시작 시간을 저장할 변수
    //private float startTime;

    //void Awake()
    //{
    //    // 싱글톤 패턴 구현
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
        // 시작 시 엔드 패널을 비활성화
        gameObject.SetActive(false);
        //// 재시작 버튼에 리스너 추가
        //retryButton.onClick.AddListener(RetryGame);
        // 게임 시작 시간 기록
        //startTime = Time.time;
    }

    // 엔드 패널을 표시하는 public 메서드
    public void ShowPanel()
    {
        // 패널 활성화
        gameObject.SetActive(true);
        // 게임 일시 정지
        //Time.timeScale = 0;
        // UI 업데이트
        UpdateUI();
    }

    // UI를 업데이트하는 private 메서드
    void UpdateUI()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sfx.Gameover);
        UpdateFinalTime();
        UpdateFinalScore();
        UpdateBestScore();
    }

    // 최종 시간을 업데이트하는 private 메서드
    void UpdateFinalTime()
    {
        finalTimeText.text = GameManager.Instance.CurGameTime.ToString("N2");
        //// 게임 진행 시간 계산
        //float playTime = Time.time - startTime;
        // 시간을 분:초 형식으로 변환
        //string timeString = string.Format("{0:00}:{1:00}", Mathf.Floor(playTime / 60), playTime % 60);
        //finalTimeText.text = "Time: " + timeString;
    }

    // 최종 점수를 업데이트하는 private 메서드
    void UpdateFinalScore()
    {
        finalScoreText.text = GameManager.Instance.CurGameScore.ToString();
        //if (GameScore.instance != null)
        //{
        //    int finalScore = GameScore.instance.GetScore();
        //    finalScoreText.text = "Score: " + finalScore.ToString();
        //}
    }

    // 최고 점수를 업데이트하는 private 메서드
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

    // 게임을 재시작하는 private 메서드
    //void RetryGame()
    //{
    //    // 게임 시간을 정상화
    //    Time.timeScale = 1;
    //    // 현재 씬을 다시 로드하여 게임 재시작
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}