using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;

    public void Awake()
    {
        if (GameManger.instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Start()
    {
        m_ScoreUI.text
            = string.Format("SCORE : {0}", m_Score);
    }
    public bool m_IsGameover = false;
    public GameObject m_GameOverUI;
    public UnityEngine.UI.Text m_ScoreUI;
    public int m_Score = 0;

    public void OnPlayerDead()
    {
        m_IsGameover = true;
        m_GameOverUI.SetActive(true);

    }
    public void OnAddScore()
    {
        m_Score++;
        m_ScoreUI.text
            = string.Format("SCORE : {0}", m_Score);
    }

}
