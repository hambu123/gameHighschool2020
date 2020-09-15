using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public List<ItemComponet> m_Items
        = new List<ItemComponet>();

    public GameObject m_CameClearUI;

    public bool m_IsPlaying;

    public void Start()
    {
        m_Items.AddRange(FindObjectsOfType<ItemComponet>());
        m_IsPlaying = true;
    }
    public void Update()
    {
        if (!m_IsPlaying) return;

        bool result = true;
        foreach(var item in m_Items)
        {
            if (item != null)
                result = false;
        }

        if(result)
        {
            m_IsPlaying = false;
            GameClear();
        }
    }
    public void GameOver()
    {
        Debug.Log("GameOver");
    }

    public void GameStart()
    {
        
    }

    public void GameClear()
    {
        m_CameClearUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("GameClear");
    }
}