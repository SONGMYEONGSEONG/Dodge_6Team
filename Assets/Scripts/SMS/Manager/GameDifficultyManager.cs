using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficultyManager : MonoBehaviour
{
    [SerializeField] private ProjectileSpawnArea[] projectileSpawnArea;
    [SerializeField] private EnemySpawnArea[] enemySpawnArea;

    [SerializeField] private float spawnTimeDifficulty = 0.2f;//난이도 변경시 적객체 생성 간격 감소
    [SerializeField] private float difficultyChangeTime = 15.0f;//해당 시간이 경과하면 난이도 변경

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

    //시간에 따른 게임 난이도 증가
    //택 1할것
    //1. 나오는 오브젝트 수의 증가 -> spawnArea SpawnTie 변경
    //2. 나오는 오브젝트 속도 및 체력 증가 -> 각 객체의 SO Speed 변경 
    IEnumerator GameTimeCheck()
    {
        Debug.Log("게임난이도 증가 코루틴 적용!");
        while (true)
        {
            yield return new WaitForSeconds(difficultyChangeTime);

            //시간 15초가 지날때마다 SpawnTime 감소하게 만들기
            for(int i =0; i < 4; i++)
            {
                projectileSpawnArea[i].SpawnTime -= spawnTimeDifficulty;
                enemySpawnArea[i].SpawnTime -= spawnTimeDifficulty;

            }
            
            Debug.Log($"난이도 증가!\n투사체 발사 생성시간 : {projectileSpawnArea[0].SpawnTime}\n적 객체 생성시간 : {enemySpawnArea[0].SpawnTime} ");

        }
    }
}
