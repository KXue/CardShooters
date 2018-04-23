using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour {
	public int m_maxHealth = 100;
	protected int m_health;
	// Use this for initialization
	void Awake () {
		m_health = m_maxHealth;
	}
	public void TakeDamage(int amount){
		m_health = Mathf.Max(0, m_health - amount);
		FeedBack();
        CheckDeath();
    }
	void CheckDeath(){
		if(m_health <= 0){
			HandleDeath();
		}
	}

	protected virtual void HandleDeath(){

	}
	protected virtual void FeedBack(){

    }
}
