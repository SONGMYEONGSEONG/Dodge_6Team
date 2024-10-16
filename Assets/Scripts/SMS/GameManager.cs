using UnityEngine;

public class GameManager : MonoBehaviour, iManager
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if( instance == null )
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameManager).Name + "Auto";
                    instance = obj.AddComponent<GameManager>();
                }

            }

            return instance;
        }
    }

    public void Initialize()
    {
        Debug.Log(gameObject.name + "Initalize ¿Ï·á!");
    }

    private void Awake()
    {
        if(instance != null)
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


}
