using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectailSpawnManager : SpawnManager
{
    public override void Initialize()
    {
        Debug.Log(gameObject.name + "Initalize 완료!");
    }

    private void Awake()
    {

    }

    private void Start()
    {
        Initialize();
    }
}