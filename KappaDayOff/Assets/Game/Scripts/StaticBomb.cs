using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBomb : AlliedBullets
{
    public StaticBomb()
    {
        
    }

    private void Awake()
    {
        damage     = GameManager.Instance.StaticBomb.Power;
        damageType = EnemyType.Machine;
        type       = BulletType.StaticBomb;
    }
    

    protected override void activateEffect()
    {
        
    }
}
