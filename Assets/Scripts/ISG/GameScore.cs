using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    // �̱��� ������ ���� ���� �ν��Ͻ�
    public static GameScore instance;

    // ������ ǥ���� UI Text ������Ʈ
    public Text scoreText;

    // ���� ������ �����ϴ� private ����
    private int currentScore = 0;

    private float survivalTime = 0f;
    private float scoreIncreaseInterval = 1f; // 1�ʸ��� ���� ����
    private float lastScoreIncreaseTime = 0f;
    private int scoreIncreaseAmount = 10; // 10���� ����

    private bool isGameActive = false; // ���� Ȱ��ȭ ���¸� ����

    // Awake �޼���: ��ũ��Ʈ�� �ʱ�ȭ�� �� ȣ���
    void Awake()
    {
        // �̱��� ���� ����
        // �� ��ũ��Ʈ�� �ν��Ͻ��� ������ ���� �ν��Ͻ��� �Ҵ�
        if (instance == null)
        {
            instance = this;
        }
        // �̹� �ν��Ͻ��� �����ϰ� ���� �ν��Ͻ��� �ٸ��� ���� ��ü �ı�
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ���� ���� �� ���� �ؽ�Ʈ ������Ʈ
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

    // ������ �߰��ϴ� public �޼���
    public void AddPoints(int points)
    {
        // ���� ������ ���޹��� ������ ����
        currentScore += points;
        // ���� �ؽ�Ʈ ������Ʈ
        UpdateScoreText();
    }

    // ���� ������ ��ȯ�ϴ� public �޼���
    public int GetScore()
    {
        return currentScore;
    }

    // ������ �ʱ�ȭ�ϴ� public �޼���
    public void ResetScore()
    {
        // ���� ������ 0���� ����
        currentScore = 0;
        // ���� �ؽ�Ʈ ������Ʈ
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
    // ���� �ؽ�Ʈ�� ������Ʈ�ϴ� private �޼���
    private void UpdateScoreText()
    {
        // scoreText�� �Ҵ�Ǿ� ������ �ؽ�Ʈ ������Ʈ
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}
