using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private EnemyTakeDamageController ETDController;
    [SerializeField] private EnemyTypeSO enemyType;

    [SerializeField] private Image healthBar;
    [SerializeField] private Image healthBGbar;

    [SerializeField] private Vector3 offset;

    private Camera cam;

    private void Awake()
    {
        ETDController = GetComponent<EnemyTakeDamageController>();
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        healthBar.transform.position = transform.position + offset;
        healthBGbar.transform.position = transform.position + offset;

        healthBar.transform.rotation = cam.transform.rotation;
        healthBGbar.transform.rotation = cam.transform.rotation;
    }

    private void Update()
    {
        HealthBarController();
    }

    void HealthBarController()
    {
        healthBar.fillAmount = ETDController.Health / enemyType.Health;
    }
}
