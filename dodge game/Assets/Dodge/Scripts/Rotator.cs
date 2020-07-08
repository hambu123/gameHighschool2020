using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
   public float m_Rotator = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, m_Rotator * Time.deltaTime, 0));
    }
}
