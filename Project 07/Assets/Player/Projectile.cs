﻿using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage = 100f;

    public float getDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
