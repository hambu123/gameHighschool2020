using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public Animator m_Animator;
    public Rigidbody2D m_Rigidbody2D;
    public AudioSource m_AudioSource;

    public AudioClip m_Jump;
    public AudioClip m_Die;

    public bool m_isGronud = false;
    public bool m_ISDead = false;

    public int m_JumpCount = 0;

    void Update()
    {
        if (m_ISDead) return;
        m_Animator.SetBool("isGronud", m_isGronud);

        if (Input.GetKeyDown(KeyCode.Space)
            && m_JumpCount<2)
        {
            m_Rigidbody2D.velocity
                = Vector2.zero;
            m_Rigidbody2D.AddForce(Vector2.up * 400);
            m_JumpCount++;

            m_AudioSource.clip = m_Jump;
            m_AudioSource.Play();
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            m_isGronud = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            m_isGronud = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Deadzoon")
        {
            m_ISDead = true;
            m_Animator.SetBool("ISDead", m_ISDead);

            GameManger.instance.OnPlayerDead();

            m_AudioSource.clip = m_Die;
            m_AudioSource.Play();

            //ㄴ나중에 GameManger에 사망처리 요청
        }
    }
}
