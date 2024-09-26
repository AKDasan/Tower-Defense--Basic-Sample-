using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance { get; private set; }

    [SerializeField] private int playerHealth;
    [SerializeField] private Text healthText;

    public static event Action PlayerTakeDamageSound;

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
        playerHealth = 10;
    }

    private void Update()
    {
        HealthController();
    }

    void HealthController()
    {
        healthText.text =  "Health : "+ playerHealth.ToString();

        if (playerHealth <= 0)
        {
            Debug.Log("Oyun bitti!");
            Destroy(gameObject);
            SceneManager.LoadScene(0); // test için
        }
    }

    public void DecreaseHealth(int value)
    {
        playerHealth -= value;
        PlayerTakeDamageSound?.Invoke();
    }
}
