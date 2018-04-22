using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public float m_coolDownTime;
    public abstract void Play(ShootHelper user);
}
