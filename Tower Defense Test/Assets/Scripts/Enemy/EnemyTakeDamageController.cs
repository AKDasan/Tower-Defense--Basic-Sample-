using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageController : MonoBehaviour
{
    [SerializeField] private float health;

    public float Health { get { return health; } }

    [SerializeField] private EnemyTypeSO enemyType;

    private void Start()
    {
        health = enemyType.Health;
    }

    private void Update()
    {
        HealthController();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FireBall") && !enemyType.isFireImmune)
        {
            health -= 35;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("IceBall") && !enemyType.isIceImmune)
        {
            health -= 35;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PoisenBall") && !enemyType.isPoisenImmune)
        {
            health -= 35;
            Destroy(collision.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Forest"))
        {
            PlayerHealthController.Instance.DecreaseHealth(enemyType.Damage);
            Destroy(gameObject);
        }
    }

    void HealthController()
    {
        if (health > enemyType.Health)
        {
            health = enemyType.Health;
        }
        if ( health <= 0)
        {
            PlayerCoinController.Instance.IncreaseCoin(5);
            Destroy(gameObject);
        }      
    }
}
