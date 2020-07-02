using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public GameObject m_Bullet;

    //public Transform m_PlayerTransform;

    public float m_RotationSpeed = 60f;
    public float m_AttackInterval = 0.2f;
    public float m_AttackCooltime = 0f;

    // Update is called once per frame
    void Update()
    {
        m_AttackCooltime += Time.deltaTime;
        if (m_AttackCooltime >= m_AttackInterval)
        {
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            m_AttackCooltime = 0;
        }

        transform.Rotate(0, 10, 0);
    }
}