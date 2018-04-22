using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class NormalBullet : ShotObject {
    public int m_damage = 10;
    void OnTriggerEnter(Collider other)
    {
        if (shooter != null && other.transform != shooter)
        {
            Health otherHealth = other.transform.GetComponent<Health>();
            if (otherHealth != null){
                otherHealth.TakeDamage(m_damage);
            }

			ShotObject otherShotObject = other.transform.GetComponent<ShotObject>();
			if(otherShotObject == null || otherShotObject.shooter != shooter){
                Destroy(gameObject);
            }
        }
    }
}
