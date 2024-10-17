using UnityEngine;
[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Item/Defult", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("Item Info")]
    public int ProjectilePower;
    public float AttackSpeed;
    public int Shield;
    public float Speed;
    public int point;
    public float CoolTime;
}
