using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Deck : CardStackUI {
    [Serializable]
    public class DeckDefiner
    {
        public Card cardType;
        public int count;
    }
	public DeckDefiner[] m_deckDefinition;

	// Use this for initialization
	void Awake () {
		PopulateDeck();
	}

	void PopulateDeck(){
		foreach(Transform child in m_cardTransform){
			Destroy(child.gameObject);
		}
		foreach(DeckDefiner definer in m_deckDefinition){
			for(int i = 0; i < definer.count; i++){
				Instantiate(definer.cardType, m_cardTransform);
			}
		}
	}
}
