using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger_Dongen : MonoBehaviour
{
    public Transform m_StartPoint;
    public PlayerControllrrDongen m_Player;

    public Text m_ClaerUI;
    public Text m_ScoreUI;

    public void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        //출발지점에서 스폰
        m_Player.gameObject.SetActive(true);
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
        //게임 클리어 메시지가 보이지 않는다
        m_ClaerUI.gameObject.SetActive(false);
        //게임 클리어 메시지가 보인다
        m_ScoreUI.gameObject.SetActive(true);
    }
        
    public void GameClaer()
    {
        //플레이어가 비활성화 된다
        //게임 클리어메시지가 보인다.
        //게임스코어 메시지가 보인다
    }

    public void ReturnToStartPoint()
    {
        //플레이어를 출발 지점으로 되돌린다.
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
        //
    }
    
}
