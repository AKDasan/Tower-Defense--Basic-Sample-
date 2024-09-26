using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private float fireRate = 2.0f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireTimer = 0f;

    public static event Action ShootPlaySound;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            FireAtClosestEnemy();
            fireTimer = 0f;
        }
    }

    private void FireAtClosestEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                float distanceToEnemy = Vector3.Distance(transform.position, hitCollider.transform.position);

                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = hitCollider.transform;
                }
            }
        }

        if (closestEnemy != null)
        {
            ShootProjectile(closestEnemy);
            ShootPlaySound?.Invoke();
        }
    }

    private void ShootProjectile(Transform target)
    {
        if (projectilePrefab && firePoint)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            ProjectileController projectileController = projectile.GetComponent<ProjectileController>();

            if (projectileController)
            {
                projectileController.SetTarget(target);
            }
        }
    }
}
