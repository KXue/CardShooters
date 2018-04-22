using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardHandler : MonoBehaviour {
	public ShootHelper m_shootHelper;
	public float m_reloadTime = 1;
	public int m_handSize = 5;
	public Deck m_deck;
	public Hand m_hand;
	public CardStackUI m_discard;
	public GameObject m_reloadText;
	private float m_reloadTimer = 0;
	private float m_fireTimer = 0;
	void Start () {
        Reload();
    }
	void Update()
	{
		if(Input.GetButton("Fire1")){
			TryToFire();
        }
		if(Input.GetButtonDown("Reload")){
			m_discard.AddCards(m_hand.GetAllCards());
			Reload();
		}
		
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		if(scroll < 0){
			m_hand.selectedIndex++;
		}else if(scroll > 0){
            m_hand.selectedIndex--;
        }

		if(m_fireTimer > 0){
			m_fireTimer -= Time.deltaTime;
		}
		if(m_reloadTimer > 0){
			m_reloadTimer -= Time.deltaTime;
		}else if(m_reloadText.activeInHierarchy){
			m_reloadText.SetActive(false);
		}
	}
	void TryToFire(){
        if (m_fireTimer <= 0 && m_reloadTimer <= 0)
        {
			if(m_hand.HasCards()){
                Card selectedCard = m_hand.GetCard();
                selectedCard.Play(m_shootHelper);
				m_discard.AddCard(selectedCard);
				m_fireTimer = selectedCard.m_coolDownTime;
			}
			else{
				Reload();
			}
        }
	}
	void Reload(){
		if(m_reloadTimer <= 0){
			m_reloadTimer = m_reloadTime;
            m_reloadText.SetActive(true);
            for (int i = 0; i < m_handSize; i++)
            {
                if (!m_deck.HasCards())
                {
                    m_deck.AddCards(m_discard.PopAllCards());
                }
                m_hand.AddCard(m_deck.PopRandomCard());
            }
            m_hand.selectedIndex = 0;
		}
	}
}
