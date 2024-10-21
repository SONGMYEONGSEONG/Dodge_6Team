using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, iManager
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameManager).Name + "Auto";
                    instance = obj.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    [SerializeField] private UI_CurScoreAndTimeAndLife uI_CurScoreAndTimeAndLife;
    private GameDifficultyManager gameDifficultyManager;
    private float curGameTime = 0.0f;
    private int curGameScore = 0;
    private int curPlayerLife = 3;

    public float CurGameTime { get { return curGameTime; } set { curGameTime = value; } }
    public int CurGameScore { get { return curGameScore; } set { curGameScore = value; } }
    public int CurPlayerLife { get { return curPlayerLife; } set { curPlayerLife = value; } }

    private bool isPlaying;


    public bool IsPlaying { get { return isPlaying; } set { isPlaying = value; } }
    public event Action OnEventGameOver;

    private void Awake()
    {
        instance = this;
       
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        gameDifficultyManager = GetComponent<GameDifficultyManager>();
        Time.timeScale = 1.0f;
        curGameTime = 0.0f;
        curGameScore = 0;
        curPlayerLife = 3;
        Debug.Log(gameObject.name + "Initalize �Ϸ�!");
    }

    private void Update()
    {
        if (isPlaying)
        {
            curGameTime += Time.deltaTime;
            uI_CurScoreAndTimeAndLife.TimeDisplay(curGameTime);

            GetLife(curPlayerLife);
        }
    }

    //������ ȹ�� �ϴ� �޼���, �̺�Ʈ�� ���� �Ұ� 
    public void GetScore(int score)
    {
        curGameScore += score;
        uI_CurScoreAndTimeAndLife.ScoreDisplay(curGameScore);
    }
    public void GetScore(EnemyController enemy)
    {
        curGameScore += enemy.EnemySO.Score;
        uI_CurScoreAndTimeAndLife.ScoreDisplay(curGameScore);
    }
    public void GetScore(ItemController item)
    {
        curGameScore += item._ItemSO.Score;
        uI_CurScoreAndTimeAndLife.ScoreDisplay(curGameScore);
    }
    public void GetTime(int time)
    {
        curGameTime += time;
        uI_CurScoreAndTimeAndLife.TimeDisplay(curGameTime);
    }
    public void GetLife(int life)
    {
        if (life <= 0)
        {
            isPlaying = false;
            OnEventGameOver?.Invoke();
            Invoke("TimeStop", 0.5f);
        }

        uI_CurScoreAndTimeAndLife.LifeDisplay(life);
    }

    private void TimeStop()
    {
        Time.timeScale = 0.0f;
    }
}
