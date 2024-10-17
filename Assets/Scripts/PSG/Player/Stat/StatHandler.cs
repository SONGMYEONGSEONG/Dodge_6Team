using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    public int ProjectilePower = 0;
    public float AttackSpeed = 0;
    public int Shield = 0;
    public float Speed = 0;
    public int point = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        ProjectilePower = playerSO.ProjectilePower;
        AttackSpeed = playerSO.AttackSpeed;
        Shield = playerSO.Shield;
        Speed = playerSO.Speed;
        point = playerSO.point;
    }
}
