﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class HpComponent : MonoBehaviour
{
    public UnityEvent m_OnDie;
    public UnityEvent m_OnTakeDamage;
    public UnityEvent m_OnTakeHeal;

    public virtual void TakeDamage(int damage)
    {
        m_OnTakeDamage.Invoke();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
