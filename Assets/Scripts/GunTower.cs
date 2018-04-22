using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTower : MonoBehaviour {
	public NormalBullet m_bulletPrefab;
	public Transform m_bulletSpawnPoint;
	public float m_bulletSpeed = 20;
	public float m_fireRate = 120;
	public float m_rotateDamping = 5;
	private Transform m_target;
	private float m_fireTime;
	private float m_fireTimer = 0;
	// Use this for initialization
	void Start () {
        m_target = Camera.main.transform;
		m_fireTime = 60 / m_fireRate;
	}
	
	// Update is called once per frame
	void Update () {
		LookAtPlayer();
		if(m_fireTimer <= 0){
			FireBullet();
			m_fireTimer = m_fireTime;
		}
		m_fireTimer -= Time.deltaTime;
	}
	void LookAtPlayer(){
		Vector3 planarPlayerPosition = m_target.position - transform.position;
		planarPlayerPosition.y = 0;
		Quaternion targetRotation = Quaternion.LookRotation(planarPlayerPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * m_rotateDamping);
	}
	void FireBullet(){
		Ray bulletDirection = new Ray(m_bulletSpawnPoint.position, (m_target.position - m_bulletSpawnPoint.position).normalized);
        NormalBullet shotBullet = Instantiate(m_bulletPrefab, bulletDirection.origin, Quaternion.LookRotation(bulletDirection.direction));
        shotBullet.GetComponent<Rigidbody>().velocity = bulletDirection.direction * m_bulletSpeed;
        shotBullet.shooter = transform;
	}
}
