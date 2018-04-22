using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardHandler : MonoBehaviour {
	public ShootHelper m_shootHelper;
	public float m_fireRate = 240f;
	public float m_reloadTime = 1;
	public int m_handSize = 5;
	public Deck m_deck;
	public Hand m_hand;
	public CardStackUI m_discard;
	public GameObject m_reloadText;
	private float m_fireTime;
	private float m_reloadTimer = 0;
	private float m_fireTimer = 0;
	void Start () {
        Reload();
		m_fireTime = 60/m_fireRate;
    }
	void Update()
	{
		if(Input.GetButton("Fire1")){
			TryToFire();
        }
		if(Input.GetButton("Reload")){
			m_discard.AddCards(m_hand.PopAllCards());
			Reload();
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
				m_fireTimer = m_fireTime;
			}
			else{
				Reload();
				m_reloadTimer = m_reloadTime;
			}
        }
	}
	void Reload(){
		m_reloadText.SetActive(true);
        for (int i = 0; i < m_handSize; i++)
        {
			if(!m_deck.HasCards()){
				m_deck.AddCards(m_discard.PopAllCards());
				Debug.Log(m_deck.transform.childCount);
            }
            m_hand.AddCard(m_deck.PopRandomCard());
        }
		m_hand.UpdateSelected(m_hand.selectedIndex);
	}
}
