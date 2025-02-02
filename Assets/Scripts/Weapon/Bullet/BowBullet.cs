﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBullet : Bullet

{
    protected override float GetCurrentDamageFor(GameObject enemy)
    {
        float d = base.GetCurrentDamageFor(enemy);
            
        if (enemy.GetComponent<Enemy>().type == EnemyType.Slug)
            d *= 1.5f;
        else if (enemy.GetComponent<Enemy>().type == EnemyType.Slug)
            d *= 0.8f;

        if (Random.Range(0, 100) % 10 == 0)
            d *= 2;
        return d;
    }
}
