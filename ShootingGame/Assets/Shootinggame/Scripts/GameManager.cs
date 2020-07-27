using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEngine.UI.Text m_ScoreUI;
    public int m_Socre = 0;

    public static GameManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    public void AddScore()
    {
        m_Socre += 10;
        m_ScoreUI.text = "Score :" + m_Socre;
    }

    public bool m_IsGameover;

    public void OnPlayerDie()
    {
        m_IsGameover = true;
    }

    public void Update()
    {
        if(m_IsGameover && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
