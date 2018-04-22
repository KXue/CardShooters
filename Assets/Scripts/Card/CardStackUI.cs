using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardStackUI : MonoBehaviour
{
    public Transform m_cardTransform;
    public Text m_cardCountText;
	void Start()
	{
		UpdateCardCount();
	}
	virtual protected void UpdateCardCount(){
		m_cardCountText.text = m_cardTransform.childCount + "";
	}
	public void AddCard(Card newCard){
		if(newCard != null){
            newCard.transform.SetParent(m_cardTransform, false);
			ResetCardTransform(newCard);
            UpdateCardCount();
		}
	}
    public void AddCards(Card[] newCards)
    {
        foreach (Card card in newCards)
        {
            card.transform.SetParent(m_cardTransform, false);
            ResetCardTransform(card);
        }
        UpdateCardCount();
    }
	public void ResetCardTransform(Card card){
		card.transform.localPosition = new Vector3();
		card.transform.localScale = new Vector3(1, 1, 1);
		SetFace(card);
	}
	public virtual void SetFace(Card card){
		card.GetComponent<CardUI>().SetFace(false);
	}
	public virtual Card PopCardAt(uint index){
		Card retCard = null;
		if(index < m_cardTransform.childCount){
            Transform cardTransform = m_cardTransform.GetChild((int)index);
			cardTransform.SetParent(null);
            UpdateCardCount();
			retCard = cardTransform.GetComponent<Card>();
		}
        return retCard;
    }
    public Card PopRandomCard(){
		return PopCardAt((uint)UnityEngine.Random.Range(0, m_cardTransform.childCount));
    }

    public virtual Card[] PopAllCards(){
		List<Card> allCards = new List<Card>();
		foreach(Transform child in m_cardTransform){
			allCards.Add(child.GetComponent<Card>());
		}
        m_cardTransform.DetachChildren();
		UpdateCardCount();
		return allCards.ToArray();
	}
	public bool HasCards(){
		return m_cardTransform.childCount > 0;
	}
}
