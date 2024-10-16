using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMonster2 : TestMonster
{
    private void Update()
    {
        transform.position += new Vector3(1, 0,0);
    }
}
