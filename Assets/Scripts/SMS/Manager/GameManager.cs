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

    [SerializeField] private UI_CurScoreAndTime uI_CurScoreAndTime;

    private float curGameTime = 0.0f;
    private int curGameScore = 0;
    private int curPlayerLife = 3;

    public float CurGameTime { get { return curGameTime; } set { curGameTime = value; } }
    public int CurGameScore { get { return curGameScore; } set { curGameScore = value; } }
    public int CurPlayerLife { get { return curPlayerLife; } set { curPlayerLife = value; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        curGameTime = 0.0f;
        curGameScore = 0;
        curPlayerLife = 3;
        Debug.Log(gameObject.name + "Initalize �Ϸ�!");
    }

    private void Update()
    {
        curGameTime += Time.deltaTime;
        uI_CurScoreAndTime.TimeDisplay(curGameTime);
        /*
        if(player.isDeath)
        {
            curPlayerLife--;

           if(curPlayerLife <=0)
            {
                //TODO CODE : UI ���â(����,��ƾ�ð�) �˾�â ���
                
            
                SceneManager.LoadScene("GameScene");
            }
        }
        else
        {
            curGameTime += Time.deltaTime;
            
        }
        */
    }

    //������ ȹ�� �ϴ� �޼���, �̺�Ʈ�� ���� �Ұ� 
    public void GetScore(int score)
    {
        curGameScore += score;
        uI_CurScoreAndTime.ScoreDisplay(curGameScore);
    }
    public void GetTime(int Time)
    {
        curGameTime += Time;
        uI_CurScoreAndTime.TimeDisplay(curGameTime);
    }
}
