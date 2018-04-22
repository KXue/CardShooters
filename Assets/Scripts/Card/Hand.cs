using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardStackUI {
	private uint m_selectedCardIndex = 0;
	public uint selectedIndex{
		get{
			return m_selectedCardIndex;
		}
		set{
			if(value < m_cardTransform.childCount && value >= 0){
                UpdateSelected(value);
                m_selectedCardIndex = value;
			}
			else if(value < 0){
				value = 0;
			}
			else if(value >= m_cardTransform.childCount && m_cardTransform.childCount > 0){
				value = (uint)(m_cardTransform.childCount - 1);
			}
		}
	}
	public void UpdateSelected(uint value){
		if(value < m_cardTransform.childCount){
            m_cardTransform.GetChild((int)m_selectedCardIndex).GetComponent<CardUI>().SetSelected(false);
            m_cardTransform.GetChild((int)value).GetComponent<CardUI>().SetSelected(true);
		}
	}
	protected override void UpdateCardCount(){
		return;
	}
    public override void SetFace(Card card)
    {
        card.GetComponent<CardUI>().SetFace(true);
    }

    public override Card[] PopAllCards()
    {
        List<Card> allCards = new List<Card>();
        foreach (Transform child in m_cardTransform)
        {
            allCards.Add(child.GetComponent<Card>());
        }
        m_cardTransform.DetachChildren();
        UpdateCardCount();
        return allCards.ToArray();
    }
	public Card GetCard(){
		Card retCard = PopCardAt(m_selectedCardIndex);
		ResetCardUI(retCard);
		UpdateSelected(m_selectedCardIndex);
		return retCard;
	}
	public void ResetCardUI(Card card){
        CardUI retCardUI = card.GetComponent<CardUI>();
        retCardUI.SetFace(false);
        retCardUI.SetSelected(false);
	}
}
