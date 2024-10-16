using UnityEngine;
[CreateAssetMenu(fileName = "PlayerDataSO", menuName ="Characterstats/Player/Defult", order = 0)]
public class PlayerSO : ScriptableObject
{
    [Header("PlayerStat Info")]
    public int HP;
    public float AttackDelay;
    public float Speed;
}
