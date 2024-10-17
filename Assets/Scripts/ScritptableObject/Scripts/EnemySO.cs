using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Characterstats/Enemy/Defult", order = 0)]
public class EnemySO : ScriptableObject
{
    [Header("PlayerStat Info")]
    public int HP;
    public float Speed;

    /*20241017 - 송명성 Enemy Data 추가*/
    [Header("Enemy Info")] 
    public string enemyName;
    public int Score;

    [Header("ObjectPooling Count")]
    public int PoolCount;
    /*20241017 - 송명성 Enemy Data 추가*/
}
