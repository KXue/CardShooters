using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Projectile {
    public int m_damage = 10;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (shooter != null && collisionInfo.transform != shooter)
        {
            Debug.Log(collisionInfo.transform + ", " + shooter);
            Health otherHealth = collisionInfo.transform.GetComponent<Health>();
            if (otherHealth != null)
            {
                otherHealth.TakeDamage(m_damage);
            }
            Destroy(gameObject);
        }
    }
}
