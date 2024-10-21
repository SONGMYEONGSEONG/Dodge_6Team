using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficultyManager : MonoBehaviour
{
    [SerializeField] private ProjectileSpawnArea[] projectileSpawnArea;
    [SerializeField] private EnemySpawnArea[] enemySpawnArea;

    [SerializeField] private float spawnTimeDifficulty = 0.2f;//���̵� ����� ����ü ���� ���� ����
    [SerializeField] private float difficultyChangeTime = 15.0f;//�ش� �ð��� ����ϸ� ���̵� ����

    private Coroutine TimeCheckCoroutine;

    private void Start()
    {
        UI_StartBtn.OnEventGameStart += GameStart;
    }
    private void OnDestroy()
    {
        UI_StartBtn.OnEventGameStart -= GameStart;
    }

    public void GameStart()
    {
        if (TimeCheckCoroutine == null)
        {
            TimeCheckCoroutine = StartCoroutine(GameTimeCheck());
        }
        else
        {
            StopCoroutine(TimeCheckCoroutine);
            TimeCheckCoroutine = StartCoroutine(GameTimeCheck());
        }
    }

    //�ð��� ���� ���� ���̵� ����
    //�� 1�Ұ�
    //1. ������ ������Ʈ ���� ���� -> spawnArea SpawnTie ����
    //2. ������ ������Ʈ �ӵ� �� ü�� ���� -> �� ��ü�� SO Speed ���� 
    IEnumerator GameTimeCheck()
    {
        Debug.Log("���ӳ��̵� ���� �ڷ�ƾ ����!");
        while (true)
        {
            yield return new WaitForSeconds(difficultyChangeTime);

            //�ð� 15�ʰ� ���������� SpawnTime �����ϰ� �����
            for(int i =0; i < 4; i++)
            {
                projectileSpawnArea[i].SpawnTime -= spawnTimeDifficulty;
                enemySpawnArea[i].SpawnTime -= spawnTimeDifficulty;

            }
            
            Debug.Log($"���̵� ����!\n����ü �߻� �����ð� : {projectileSpawnArea[0].SpawnTime}\n�� ��ü �����ð� : {enemySpawnArea[0].SpawnTime} ");

        }
    }
}
