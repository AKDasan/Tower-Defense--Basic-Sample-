using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyType")]
public class EnemyTypeSO : ScriptableObject
{
    public float Health;
    public int Damage;
    public float Speed;
    public bool isFireImmune;
    public bool isIceImmune;
    public bool isPoisenImmune;
}
