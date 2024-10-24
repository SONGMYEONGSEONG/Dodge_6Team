using UnityEngine;
[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Item/Defult", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("Item Info")]
    public string ItemName;
    public int PoolCount;
    public int ProjectilePower;
    public float AttackSpeed;
    public int Shield;
    public float Speed;
    public int Score;
    public float CoolTime;
}
