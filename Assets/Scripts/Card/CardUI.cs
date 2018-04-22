using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour {
    public Sprite m_cardBack;
    public Sprite m_cardFront;
    public Image m_displayImage;
    public Transform m_borderTransform;
    public bool m_selected = false;
    public bool m_isFront = false;
    void Start()
    {
        m_displayImage.sprite = m_isFront ? m_cardFront : m_cardBack;
        m_borderTransform.gameObject.SetActive(m_selected);
    }
	public void SetFace(bool isFront){
        m_isFront = isFront;
		m_displayImage.sprite = isFront ? m_cardFront : m_cardBack;
	}
    public void SetSelected(bool selected){
        m_selected = selected;
        m_borderTransform.gameObject.SetActive(m_selected);

    }
}
