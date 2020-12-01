using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Fairy, Youkai, Machine
}

public class EnemyStats : MonoBehaviour
{
    private int HP = 10;
    private EnemyType type = EnemyType.Fairy;
    public void TakeDamage(int damage, EnemyType damageType)
    {
        if (damageType == type)
        {
            HP -= damage;
            if (HP <= 0)
                Destroy(gameObject);
        }
        else
        {
            Debug.Log("No damage");
        }
    }
}
