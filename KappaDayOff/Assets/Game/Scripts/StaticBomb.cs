using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBomb : AlliedBullets
{
    public StaticBomb()
    {
        damage = UpgradableStats.Instance().GetStaticBombPower();
        damageType = EnemyType.Machine;
        type = BulletType.StaticBomb;
    }

    protected override void activateEffect()
    {
        
    }
}
