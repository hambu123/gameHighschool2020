using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : MonoBehaviour
{
    public float m_Speed = 3f;

    public float m_LifeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * m_Speed * Time.deltaTime;
    }
}
