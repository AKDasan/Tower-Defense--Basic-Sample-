using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip preparationStageEndSound;
    [SerializeField] private AudioClip enemySpawnSound;
    [SerializeField] private AudioClip enemyTakeDamageSound;
    [SerializeField] private AudioClip towerPlaceSound;
    [SerializeField] private AudioClip towerShootSound;
    [SerializeField] private AudioClip playerTakeDamageSound;
    [SerializeField] private AudioClip playerCoinIncrease;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        TowerController.ShootPlaySound += TowerShootSound;
        BuildController.PlacePlaySound += TowerPlaceSound;
        PlayerHealthController.PlayerTakeDamageSound += PlayerTakeDamageSound;
        PlayerCoinController.PlayerIncreaseCoinSound += playerCoinIncreaseSound;
        GameManager.PrePhaseEndSound += PlayPreStageEndSound;
    }

    void PlayPreStageEndSound()
    {
        audioSource?.PlayOneShot(preparationStageEndSound);
    }

    void EnemySpawnSound()
    {
        audioSource?.PlayOneShot(enemySpawnSound);
    }

    void EnemyTakeDamageSound()
    {
        audioSource?.PlayOneShot(enemyTakeDamageSound);
    }

    void TowerPlaceSound()
    {
        audioSource?.PlayOneShot(towerPlaceSound);
    }

    void TowerShootSound()
    {
        audioSource?.PlayOneShot(towerShootSound);
    }

    void PlayerTakeDamageSound()
    {
        audioSource?.PlayOneShot(playerTakeDamageSound);
    }

    void playerCoinIncreaseSound()
    {
        audioSource?.PlayOneShot(playerCoinIncrease);
    }

    private void OnDisable()
    {
        TowerController.ShootPlaySound -= TowerShootSound;
        BuildController.PlacePlaySound -= TowerPlaceSound;
        PlayerHealthController.PlayerTakeDamageSound -= PlayerTakeDamageSound;
        PlayerCoinController.PlayerIncreaseCoinSound += playerCoinIncreaseSound;
        GameManager.PrePhaseEndSound -= PlayPreStageEndSound;
    }
}
