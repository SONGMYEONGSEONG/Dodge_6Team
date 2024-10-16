using UnityEngine;

public class ShooterEnemyController : EnemyController
{
    [SerializeField] private EnemySO enemySO;
    private void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove(findPlayer, enemySO.Speed);
    }
}
