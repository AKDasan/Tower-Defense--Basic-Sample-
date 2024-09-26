using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Preparation,
    Battle
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState currentGameState;

    [SerializeField] private Button stageButton;
    [SerializeField] private float second = 60;
    [SerializeField] private Text secondText;

    [SerializeField] private EnemySpawnController enemySpawnController;

    public static event Action PrePhaseEndSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        currentGameState = GameState.Preparation;
    }

    private void Update()
    {
        StateController();
        secondText.text = Mathf.CeilToInt(second).ToString();
    }

    void StateController()
    {
        if (currentGameState == GameState.Preparation)
        {
            secondText.gameObject.SetActive(true);
            stageButton.gameObject.SetActive(true);

            second -= 1 * Time.deltaTime;
            if (second <= 0f) 
            {
                StageChange();
                second = 60;
            }
        }
        else
        {
            stageButton.gameObject.SetActive(false);
            secondText.gameObject.SetActive(false);        
        }
    }

    public void StageChange()
    {
        if (currentGameState == GameState.Preparation)
        {
            second = 60;
            PrePhaseEndSound?.Invoke();
            currentGameState = GameState.Battle;
            enemySpawnController.IsSpawnable = true;
        }
        else
        {
            currentGameState = GameState.Preparation;
            enemySpawnController.IsSpawnable = false;
        }
    }
}
