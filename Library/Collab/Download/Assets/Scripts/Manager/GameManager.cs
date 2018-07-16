using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  public enum GameState
{
    StageA = 0,//귀신함정
    StageB,//데자뷰
    StageC,// 데자뷰영상
    StageD,//전화부스
    StageE,//뒷길 
    StageF // 시신획득
}

// gps 좌표와 가까우면 bool값이 true, 멀어지면 bool값이 false


public class GameManager : MonoBehaviour {

  


    public GameState gameState = GameState.StageA;
    public GameObject distanceManager;
    public GameObject gpsSystem;
    public GameObject player;


    public ConTower conTower;
   

    void Awake()
    {

    }


    void Start()
    {
        gameState = GameState.StageA;

        conTower = GetComponent<ConTower>();

    }


    void Update()
    {
        switch (gameState)
        {

            case GameState.StageA:
                {
                    //귀신 함정 
                    //플레이어와 유리함정 사이의 거리가 5m 이하일때의 상황 발생 

                    conTower.ConTowerPos();
                    gameState = GameState.StageB;

                }
                break;

            case GameState.StageB:
                {
                }
                break;
            case GameState.StageC:
                {
                }
                break;
            case GameState.StageD:
                {
                }
                break;
            case GameState.StageE:
                {
                }
                break;


        }

    }


}
