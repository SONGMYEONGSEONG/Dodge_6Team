using UnityEngine;

public class ChildProjectile2 : TestProjectile
{
    private void Update()
    {
        //transform.position += new Vector3(0, -0.1f, 0);

        if (transform.position.y > (float)EnumSpawnAreaLimit.UPDownLimit
        ||
        transform.position.y < -(float)EnumSpawnAreaLimit.UPDownLimit
        ||
        transform.position.x > (float)EnumSpawnAreaLimit.LeftRightLimit
        ||
        transform.position.x < -(float)EnumSpawnAreaLimit.LeftRightLimit
        )
        {
            base.CompletePurPose();
        }
    }
}