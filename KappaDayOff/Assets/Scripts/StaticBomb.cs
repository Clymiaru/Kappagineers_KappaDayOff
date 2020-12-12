using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBomb : AlliedBullets
{
    public StaticBomb()
    {
        damageType = EnemyType.Machine;
        type = BulletType.StaticBomb;
    }

    protected override void activateEffect()
    {
        
    }
}
