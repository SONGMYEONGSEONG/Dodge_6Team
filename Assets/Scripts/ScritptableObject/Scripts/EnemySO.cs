using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Characterstats/Enemy/Defult", order = 0)]
public class EnemySO : ScriptableObject
{
    [Header("PlayerStat Info")]
    public int HP;
    public float Speed;
}
