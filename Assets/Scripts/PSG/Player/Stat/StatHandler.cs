using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    public int ProjectilePower;
    public float AttackSpeed;
    public int Shield;
    public float Speed;
    public int point;
    // Start is called before the first frame update
    void Start()
    {
        ProjectilePower = playerSO.ProjectilePower;
        AttackSpeed = playerSO.AttackSpeed;
        Shield = playerSO.Shield;            
        Speed = playerSO.Speed;
        point = playerSO.point;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
