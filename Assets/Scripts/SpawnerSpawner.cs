using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class SpawnDefinition
{
    public Transform spawnPrefab;
    public uint spawnWeight;
}
public class SpawnerSpawner : MonoBehaviour {
	public Vector3 m_spawnVolume;
	public float m_spawnRate; //spawns per second
	public float m_spawnRateGrowth;
	public uint m_mobSize;
	public uint m_mobSizeRange;
	public SpawnDefinition[] m_spawnDefinition;
	private uint m_totalSpawnWeight = 0;
	private float m_spawnTime;
	private float m_spawnTimer = 0;
	// Use this for initialization
	void Start () {
		UpdateSpawnTime();
		InvokeRepeating("UpdateSpawnRate", 0, m_spawnTime);
		foreach(SpawnDefinition def in m_spawnDefinition){
			m_totalSpawnWeight += def.spawnWeight;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(m_spawnTimer <= 0){
            SpawnSpawners();
            m_spawnTimer = m_spawnTime;
        }
		m_spawnTimer -= Time.deltaTime;
	}
	void SpawnSpawners(){
		uint lowerBound = (uint)Mathf.Max(1, m_mobSize - m_mobSizeRange);
		uint spawnCount = (uint)UnityEngine.Random.Range((int)lowerBound, (int)(m_mobSize + m_mobSizeRange + 1));
		for(int i = 0; i < spawnCount; i++){
			SpawnSpawner();
		}
	}
	void SpawnSpawner(){
		int spawnNumber = UnityEngine.Random.Range(0, (int)m_totalSpawnWeight);
		Transform selectedPrefab = null;
		foreach(SpawnDefinition def in m_spawnDefinition){
			spawnNumber -= (int)def.spawnWeight;
			if(spawnNumber < 0){
				selectedPrefab = def.spawnPrefab;
				break;
			}
		}
		if(selectedPrefab != null){
            Vector3 spawnPosition = new Vector3(
                UnityEngine.Random.Range(transform.position.x - m_spawnVolume.x, transform.position.x + m_spawnVolume.x),
                UnityEngine.Random.Range(transform.position.y - m_spawnVolume.y, transform.position.y + m_spawnVolume.y),
                UnityEngine.Random.Range(transform.position.z - m_spawnVolume.z, transform.position.z + m_spawnVolume.z)
            );
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
		}
	}
	void UpdateSpawnRate(){
		m_spawnRate *= m_spawnRateGrowth;
		UpdateSpawnTime();
	}
	void UpdateSpawnTime(){
		m_spawnTime = 1/m_spawnRate;
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0, 1, 0, 1);
		Gizmos.DrawWireCube(transform.position, m_spawnVolume);
	}
}
