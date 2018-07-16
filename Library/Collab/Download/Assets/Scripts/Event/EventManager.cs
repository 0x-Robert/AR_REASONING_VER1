using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HintState
{
    AnyTime, OnTime
}
public enum HintKinds
{
    ConTower, Bench, Card, Shovel, CallBox, Things, Parts
}

public class EventManager : MonoBehaviour {

    public GameManager gm;

    public GameObject conTowerHint;     //통제실 유도 힌트 - 항시 켜져있음
    public GameObject benchHint;        //밴치 유도 - 접근하면 돌아 안도록 유도(반투명Objet로 연출하던지 기타 가이드로 돌아 안기 유도)
    public GameObject stage;
    public GameObject callCard;         //전화 카드
    public GameObject callBox;
    public GameObject numPad;           //숫자패드 - 객체화하여 숫자키, 카드삽입구, View 구성할것
    public Text viewPanel;              //좌표표시하는 곳
    public GameObject cardInput;        //전화카드 삽입구
    public GameObject thingsObj;        //소지품
    public GameObject shovelIcon;       //삽아이콘
    public GameObject part;             //시신 부위

    //아이템 획득
    private bool getCard    = false;
    private bool getThings  = false;
    private bool getParts   = false;
    

    public void CallTouchEvent(HintKinds hk)
    {
        switch (hk)
        {
            case HintKinds.ConTower:    //관리실이벤트 실행
                //TODO 귀신이펙트 스타트 & GM에 다음단계 보고

                CallNextState(HintKinds.ConTower);
                break;
            case HintKinds.Bench:       //벤치이벤트 실행
                stage.SetActive(true);  //데쟈뷰 오브젝트 활성화(애니메이션 자동 실행)
                //스크린연출 켬 - 점진적으로 어두워짐
                break;
            case HintKinds.Card:        //스테이지에서 전화카드 습득 시
                getCard = true;             //카드습득여부를 알 수 있도록 변수 체크
                callCard.SetActive(false);  //카드습득 시 스테이지에 있던 카드는 안보이도록

                CallNextState(HintKinds.Card);
                break;
            case HintKinds.CallBox:     //전화부스이벤트 실행
                numPad.SetActive(true); //키패드 활성화
                break;
            case HintKinds.Things:      //소지품획득시 실행
                getThings = true;       //소지품획득 체크
                thingsObj.SetActive(false);

                CallNextState(HintKinds.ConTower);
                break;
            case HintKinds.Shovel:      //삽질아이콘이벤트 실행
                //TODO 삽질유도 - 슬라이드 반응
                break;
            case HintKinds.Parts:       //시신획득
                getParts = true;        //시신획득 체크
                part.SetActive(false);  //시신오브젝트 비활성화
                break;
        }
    }
    public void CallProcessLv(HintKinds hk, bool value)
    {
        switch (hk)
        {
            case HintKinds.ConTower:    conTowerHint.SetActive(value);  break;
            case HintKinds.Bench:       benchHint.SetActive(value);     break;
            case HintKinds.CallBox:     callBox.SetActive(value);       break;
            case HintKinds.Things:      thingsObj.SetActive(value);     break;  //끄지 않음
            case HintKinds.Shovel:      shovelIcon.SetActive(value);    break;
            case HintKinds.Parts:
                break;
        }
    }

    public void SetThingsGPS()  //CallPad에 카드삽입구 터치 시 소지품 좌표 표시
    {
        if (getCard)
        {
            cardInput.SetActive(true);
            getCard = false;
            viewPanel.text = "717 / 6996";

            //TODO: GM에 다음단계 콜
            CallNextState(HintKinds.ConTower);
        }
    }
    public void CloseCallPad()  //콜패드 외곽 터치 시
    {
        numPad.SetActive(false);
    }
    public void CallNextState(HintKinds hk) //GM에게 다음단계로의 진행을 알림
    {

    }

    //IEnumerator SetMovieColor_0()
    //{
    //    Color col;
    //    videoPanel.color = col = new Color(1, 1, 1, 0);
    //    while(videoPanel.color != Color.white)
    //    {
    //        col.a += 0.05f;
    //        videoPanel.color = col;
    //        if (col.a >= 1) break; 
    //        yield return null;
    //    }
    //}
    //IEnumerator SetMovieColor_1()
    //{
    //    Color col;
    //    videoPanel.color = col = new Color(1, 1, 1, 0);
    //    while (videoPanel.color != Color.white)
    //    {
    //        col.a += 0.05f;
    //        videoPanel.color = col;
    //        if (col.a >= 1) break;
    //        yield return null;
    //    }
    //}


}
