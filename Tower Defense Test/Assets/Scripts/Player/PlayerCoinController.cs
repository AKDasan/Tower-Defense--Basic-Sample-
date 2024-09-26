using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCoinController : MonoBehaviour
{
    public static PlayerCoinController Instance { get; private set; }

    [SerializeField] private BuildController buildController;

    [SerializeField] private int playerCoin;

    [SerializeField] private Text coinText;

    [SerializeField] private Button fireTowerBTN;
    [SerializeField] private Button iceTowerBTN;
    [SerializeField] private Button poisenTowerBTN;

    public static event Action PlayerIncreaseCoinSound;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        buildController = FindObjectOfType<BuildController>();
        playerCoin = 125;
    }

    private void Update()
    {
        CoinController();
        TowerBTNController();
    }

    void CoinController()
    {
        coinText.text = "Coin : " + playerCoin.ToString();
    }

    void TowerBTNController()
    {
        if (playerCoin < buildController.TowerValue)
        {
            fireTowerBTN.interactable = false;
            iceTowerBTN.interactable = false;
            poisenTowerBTN.interactable = false;
        }
        else
        {
            fireTowerBTN.interactable = true;
            iceTowerBTN.interactable = true;
            poisenTowerBTN.interactable = true;
        }
    }

    public void IncreaseCoin(int value)
    {
        playerCoin += value;
        PlayerIncreaseCoinSound?.Invoke();
    }

    public void DecreaseCoin(int value)
    {
        playerCoin -= value;
    }
}
