using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class NormalBullet : ShotObjects {
    public int m_damage = 10;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (shooter != null && collisionInfo.transform != shooter)
        {
            Health otherHealth = collisionInfo.transform.GetComponent<Health>();
            if (otherHealth != null){
                otherHealth.TakeDamage(m_damage);
            }
			
			ShotObjects otherShotObject = collisionInfo.transform.GetComponent<ShotObjects>();
			if(otherShotObject == null || otherShotObject.shooter != shooter){
                Destroy(gameObject);
            }
        }
    }
}
