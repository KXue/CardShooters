using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour {
	public Image m_healthUI;
	public int m_maxHealth = 100;
	private int m_health;
	// Use this for initialization
	void Start () {
		m_health = m_maxHealth;
	}
	public void TakeDamage(int amount){
		m_health = Mathf.Max(0, m_health - amount);
		CheckDeath();
		UpdateHealthUI();
	}
	void CheckDeath(){
		if(m_health <= 0){
			//game over
		}
	}
	void UpdateHealthUI(){
		if(m_healthUI != null){
            m_healthUI.fillAmount = (float)m_health / (float)m_maxHealth;
		}
	}

}
