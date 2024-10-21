using UnityEngine;
[CreateAssetMenu(fileName = "PlayerDataSO", menuName ="Characterstats/Player/Defult", order = 0)]
public class PlayerSO : ScriptableObject
{
    [Header("PlayerStat Info")]
    public int ProjectilePower;
    public float AttackSpeed;
    public int Shield;
    public float Speed;
    public int point;
}
