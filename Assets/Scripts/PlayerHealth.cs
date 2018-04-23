using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health {
    public Image m_healthUI;
	public UIHandler m_uIHandler;
	private AudioHandler m_audioHandler;
    void Start()
	{
        m_audioHandler = GetComponent<AudioHandler>();
	}
    protected override void HandleDeath()
    {
        m_audioHandler.PlaySound("Die");
        m_uIHandler.QuitGame();
    }
    protected override void FeedBack()
    {
        m_audioHandler.PlaySound("TakeDamage");
		UpdateHealthUI();
    }

    void UpdateHealthUI()
    {

        m_healthUI.fillAmount = (float)m_health / (float)m_maxHealth;
    }
}
