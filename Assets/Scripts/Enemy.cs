using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public Transform m_target;
	public float m_speed = 5;
	public int m_damage = 10;
	private Rigidbody m_rigidbody;
	void Start () {
		m_target = Camera.main.transform.parent;
		m_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerDirection = m_target.position - transform.position;
		playerDirection.y = 0;
		playerDirection.Normalize();
		playerDirection *= m_speed;

		Vector3 velocity = m_rigidbody.velocity;
        velocity.x = playerDirection.x;
        velocity.z = playerDirection.z;

        m_rigidbody.velocity = velocity;
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.transform == m_target){
			Health playerHealth = collisionInfo.transform.GetComponent<Health>();
			playerHealth.TakeDamage(m_damage);
			Destroy(gameObject);
		}
	}
}
