using UnityEngine;

public class ChildProjectile1 : TestProjectile
{
    private void Update()
    {
        transform.position += new Vector3(0, -0.1f, 0);

        if (transform.position.y <= -15.0f)
        {
            base.CompletePurPose();
        }
    }
}
