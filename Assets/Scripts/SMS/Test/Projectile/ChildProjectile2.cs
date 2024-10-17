using UnityEngine;

public class ChildProjectile2 : TestProjectile
{
    private void Update()
    {
        //transform.position += new Vector3(0, -0.1f, 0);

        if (transform.position.y <= -5.0f)
        {
            base.CompletePurPose();
        }
    }
}