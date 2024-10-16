using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMonster1 : TestMonster
{
    private void Update()
    {
        transform.position += new Vector3(-0.1f, 0, 0);

        if (transform.position.x <= -5.0f)
        {
            base.CompletePurPose();
        }
    }
}
