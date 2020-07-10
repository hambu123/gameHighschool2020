using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger_Dongen : MonoBehaviour
{
    public Transform m_StartPoint;
    public PlayerControllrrDongen m_Player;

    public Text m_ClearUI;
    public Text m_ScoreUI;


    public float m_Score = 0;
    public bool m_isPlaying;

    public void Start()
    {
        GameStart();
    }


    void Update()
    {
        //시간당 점수업
        if (m_isPlaying)
        {
            m_Score = m_Score + Time.deltaTime;
            m_ScoreUI.text = string.Format("Score : {0}", m_Score);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameStart();
            }
        }
    }



    public void GameStart()
    {
        m_isPlaying = true;
        //출발지점에서 스폰
        m_Player.gameObject.SetActive(true);
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
        //게임 클리어 메시지가 보이지 않는다
        m_ClearUI.gameObject.SetActive(false);
        //게임 클리어 메시지가 보인다
        m_ScoreUI.gameObject.SetActive(true);
    }
        
    public void GameClaer()
    {
        m_isPlaying = false;
        //플레이어가 비활성화 된다
        m_Player.gameObject.SetActive(false);
        //게임 클리어메시지가 보인다.
        m_ClearUI.gameObject.SetActive(true);
        //게임스코어 메시지가 보인다
        m_ScoreUI.gameObject.SetActive(true);

        //활성화가 적은 비활성화
        // SetActivityAllGameObject(typeof(BulletSpawner), false);
        //SetActivityAllGameObjectz
        var enemisType1 = FindObjectsOfType<rotate>();
        foreach (var enemy in enemisType1)
        {
            enemy.gameObject.SetActive(false);
        }
        var enemisType2 = FindObjectsOfType<BulletSpawner>();
        foreach (var enemy in enemisType2)
        {
            enemy.gameObject.SetActive(false);
        }

        //탄환삭제
        //해보자
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject); //Destroy(게임오브젝트) 게임오브젝트를 제거하는
        }

        //클리어 타임 빠른 1,2,3위를 저장 표시하기]
        float num1 = PlayerPrefs.GetFloat("Num1", 999);
        float num2 = PlayerPrefs.GetFloat("Num2", 999);
        float num3 = PlayerPrefs.GetFloat("Num3", 999);

        if(m_Score < num1)
        {
            num3 = num2;
            num2 = num1;
            num1 = m_Score;
        }
        else if(m_Score < num2)
        {
            num3 = num2;
            num2 = m_Score;
        }
        else if (m_Score < num3)
        {
            num3 = m_Score;
        }

        PlayerPrefs.SetFloat("num1", num1);
        PlayerPrefs.SetFloat("num2", num2);
        PlayerPrefs.SetFloat("num3", num3);
        PlayerPrefs.Save();

        m_ClearUI.text = string.Format("Game Claer\n 1위 : {0}, 2위 : {1}, 3위 : {2}", num1, num2, num3);
    }

    public void SetActivityAllGameObject(Type type, bool isActivity)
    {
        var objects = FindObjectsOfType(type);
        foreach (var obj in objects)
        {
            var gobj = (GameObject)obj;
            gobj.SetActive(false);
        }
    }

    public void ReturnToStartPoint()
    {
        //플레이어를 출발 지점으로 되돌린다.
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
        //
    }
    
}
