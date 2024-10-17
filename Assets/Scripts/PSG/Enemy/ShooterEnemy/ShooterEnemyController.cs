using UnityEngine;

public class ShooterEnemyController : EnemyController
{
    /*20241017 - 송명성 위치 변경 ShooterEnemyController -> EnemyController*/
    //[SerializeField] private EnemySO enemySO;
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
