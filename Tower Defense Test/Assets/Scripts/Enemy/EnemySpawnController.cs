using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] stage1_enemies;
    [SerializeField] private GameObject[] stage2_enemies;
    [SerializeField] private GameObject[] stage3_enemies;
    [SerializeField] private GameObject[] stage4_enemies;
    [SerializeField] private GameObject[] stage5_enemies;

    private GameObject[] currentStage;
    private int currentStageIndex = 1;

    [SerializeField] private int spawnTime = 2;

    [SerializeField] private bool isSpawnable = false;
    public bool IsSpawnable { get { return isSpawnable; } set { isSpawnable = value; } }

    private bool spawningStarted = false;
    private int enemyIndex = 0;

    private void Start()
    {
        currentStage = stage1_enemies;
    }

    private void Update()
    {
        stageController();

        if (isSpawnable && !spawningStarted)
        {
            StartCoroutine(SpawnEnemy(currentStage));
            spawningStarted = true;
        }
    }

    IEnumerator SpawnEnemy(GameObject[] enemiesList)
    {
        while (enemyIndex < enemiesList.Length)
        {
            Instantiate(enemiesList[enemyIndex], spawnPoint.position, Quaternion.identity);
            enemyIndex++;
            yield return new WaitForSeconds(spawnTime);
        }

        isSpawnable = false;
        spawningStarted = false;
        enemyIndex = 0;
        currentStageIndex++;

        GameManager.Instance.StageChange();
    }

    void stageController()
    {
        switch (currentStageIndex)
        {
            case 1:
                currentStage = stage1_enemies;
                break;
            case 2:
                currentStage = stage2_enemies;
                break;
            case 3:
                currentStage = stage3_enemies;
                break;
            case 4:
                currentStage = stage4_enemies;
                break;
            case 5:
                currentStage = stage5_enemies;
                break;
            default:
                break;
        }
    }
}
