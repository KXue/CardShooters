using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {
	public float m_lifeTime = 5;
	public Transform shooter;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, m_lifeTime);
	}
}
