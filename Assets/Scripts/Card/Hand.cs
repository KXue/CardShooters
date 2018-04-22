using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardStackUI {
	private int m_selectedCardIndex = 0;
	public int selectedIndex{
		get{
			return m_selectedCardIndex;
		}
		set{
            value = Mathf.Clamp(value, 0, m_cardTransform.childCount - 1);
            UpdateSelected(value);
            m_selectedCardIndex = value;
		}
	}
	void Awake()
	{
		m_defaultFaceUp = true;
	}
	public void UpdateSelected(int value){
		if(m_cardTransform.childCount > 0){
		    if(m_selectedCardIndex < m_cardTransform.childCount && m_selectedCardIndex >= 0){
                Transform previouslySelected = m_cardTransform.GetChild(m_selectedCardIndex);
                previouslySelected.GetComponent<CardUI>().SetSelected(false);
            }
			value = Mathf.Clamp(value, 0, m_cardTransform.childCount - 1);
            Transform selected = m_cardTransform.GetChild((int)value);
            selected.GetComponent<CardUI>().SetSelected(true);
		}
	}
	protected override void UpdateCardCount(){
		return;
	}
	public Card GetCard(){
        m_selectedCardIndex = Mathf.Clamp(m_selectedCardIndex, 0, m_cardTransform.childCount - 1);
        Card retCard = PopCardAt((uint)m_selectedCardIndex);
		ResetCardUI(retCard);
        UpdateSelected(m_selectedCardIndex);
		return retCard;
	}
	public Card[] GetAllCards(){
		Card[] retCards = PopAllCards();
		foreach(Card card in retCards){
			ResetCardUI(card);
        }
        m_selectedCardIndex = Mathf.Clamp(m_selectedCardIndex, 0, m_cardTransform.childCount - 1);
        UpdateSelected(m_selectedCardIndex);
		return retCards;
	}
	public void ResetCardUI(Card card){
        CardUI retCardUI = card.GetComponent<CardUI>();
        retCardUI.SetFace(false);
        retCardUI.SetSelected(false);
	}
}
