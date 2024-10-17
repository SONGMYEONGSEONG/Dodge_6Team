using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    // 싱글톤 패턴을 위한 정적 인스턴스
    public static GameScore instance;

    // 점수를 표시할 UI Text 컴포넌트
    public Text scoreText;

    // 현재 점수를 저장하는 private 변수
    private int currentScore = 0;

    private float survivalTime = 0f;
    private float scoreIncreaseInterval = 1f; // 1초마다 점수 증가
    private float lastScoreIncreaseTime = 0f;
    private int scoreIncreaseAmount = 10; // 10점씩 증가

    private bool isGameActive = false; // 게임 활성화 상태를 추적

    // Awake 메서드: 스크립트가 초기화될 때 호출됨
    void Awake()
    {
        // 싱글톤 패턴 구현
        // 이 스크립트의 인스턴스가 없으면 현재 인스턴스를 할당
        if (instance == null)
        {
            instance = this;
        }
        // 이미 인스턴스가 존재하고 현재 인스턴스와 다르면 현재 객체 파괴
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 게임 시작 시 점수 텍스트 업데이트
        UpdateScoreText();
    }
    public void StartGame()
    {
        isGameActive = true;
        survivalTime = 0f;
        lastScoreIncreaseTime = 0f;
        ResetScore();
    }
    public void EndGame()
    {
        isGameActive = false;
    }

    // 점수를 추가하는 public 메서드
    public void AddPoints(int points)
    {
        // 현재 점수에 전달받은 점수를 더함
        currentScore += points;
        // 점수 텍스트 업데이트
        UpdateScoreText();
    }

    // 현재 점수를 반환하는 public 메서드
    public int GetScore()
    {
        return currentScore;
    }

    // 점수를 초기화하는 public 메서드
    public void ResetScore()
    {
        // 현재 점수를 0으로 설정
        currentScore = 0;
        // 점수 텍스트 업데이트
        UpdateScoreText();
    }

    private void Update()
    {
        if (isGameActive)
        {
            survivalTime += Time.deltaTime;
            IncreaseScoreOverTime();
        }
    }
    private void IncreaseScoreOverTime()
    {
        if (survivalTime - lastScoreIncreaseTime >= scoreIncreaseInterval)
        {
            AddPoints(scoreIncreaseAmount);
            lastScoreIncreaseTime = survivalTime;
        }
    }
    // 점수 텍스트를 업데이트하는 private 메서드
    private void UpdateScoreText()
    {
        // scoreText가 할당되어 있으면 텍스트 업데이트
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}
