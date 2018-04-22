using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform m_enemySpawnPoint;
	public Transform m_enemyPrefab;
    public float m_fireRate = 6;
	public int m_mobSize = 3;
	public float m_launchVelocity = 5f;
    private Transform m_target;
    private float m_fireTime;
    private float m_fireTimer = 0;

	void Start()
	{
        m_target = Camera.main.transform;
        m_fireTime = 60 / m_fireRate;
	}

    void Update()
    {
        if (m_fireTimer <= 0)
        {
            SpawnEnemies();
            m_fireTimer = m_fireTime;
        }
        m_fireTimer -= Time.deltaTime;
    }

	void SpawnEnemies(){
		float offsetmagnitude = (m_enemyPrefab.localScale.magnitude * 0.5f);
		Vector3 centreOffset = new Vector3();
		float offsetAngle = 2 * Mathf.PI / m_mobSize;

		for(int i = 0; i < m_mobSize; i++){
			centreOffset.x = Mathf.Cos(offsetAngle * i) * offsetmagnitude;
			centreOffset.z = Mathf.Sin(offsetAngle * i) * offsetmagnitude;
			Transform enemy = Instantiate(m_enemyPrefab, m_enemySpawnPoint.position + centreOffset, Quaternion.identity);
			enemy.GetComponent<Rigidbody>().velocity = enemy.position - m_enemySpawnPoint.position + Vector3.up * m_launchVelocity;
		}
	}
}
