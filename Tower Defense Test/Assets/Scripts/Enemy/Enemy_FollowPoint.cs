using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_FollowPoint : MonoBehaviour
{
    public Transform[] points;
    private int pointIndex = 0;
    public float speed;
    public float rotationSpeed = 5f;

    [SerializeField] private EnemyTypeSO enemyType;

    private void Start()
    {
        speed = enemyType.Speed;

        GameObject[] pointObjects = GameObject.FindGameObjectsWithTag("Points");

        pointObjects = pointObjects.OrderBy(point => point.name).ToArray();

        points = new Transform[pointObjects.Length];

        for (int i = 0; i < pointObjects.Length; i++)
        {
            points[i] = pointObjects[i].transform;
        }
    }

    void Update()
    {
        FollowPoints();
    }

    void FollowPoints()
    {
        if (pointIndex < points.Length)
        {
            Vector3 target = points[pointIndex].position;
            Vector3 direction = target - transform.position;

            RotateEnemy(target);

            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target) < 0.2f)
            {
                pointIndex++;
            }
        }
    }

    void RotateEnemy(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
