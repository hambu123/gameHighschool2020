using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float Speed = 3f;

    public Bullet m_Bulletfrefabs;
    public float m_AttackDely = 0.5f;
    public float m_AttackCooldown = 0f;

    public Transform[] m_Firemuzzle;

    

    private void Start()
    {
    
    }
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        this.transform.Translate(new Vector3(xMove, yMove, 0));

        //총알발사
        //Gameobject.instantie

        if(Input.GetKey(KeyCode.Space)&& m_AttackCooldown <= 0)
        {
            foreach (var firemuzzle in m_Firemuzzle)
            {
                var bullet = GameObject.Instantiate(m_Bulletfrefabs, firemuzzle.position, firemuzzle.rotation);
            }
            //총알생성
            
            m_AttackCooldown = m_AttackDely;
        }
        m_AttackCooldown -= Time.deltaTime;
        
    }
}
  