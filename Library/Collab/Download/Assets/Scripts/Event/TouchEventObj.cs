using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEventObj : MonoBehaviour {

    public EventManager em;

	void Update () {
        ProcClick();
    }
    void ProcClick()
    {
    #if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            ClickPosProc(Input.mousePosition);
        }

    #else
        if(Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                ClickPosProc(Input.touches[i].position);
            }
        }
    #endif
    }

    //터치 좌표에 있는 오브젝트를 구한다.
    void ClickPosProc(Vector3 tPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(tPos);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            switch(hit.collider.gameObject.name)
            {
                case "ConTower":
                    em.CallTouchEvent(HintKinds.ConTower);
                    break;
                case "Bench":
                    em.CallTouchEvent(HintKinds.Bench);
                    break;
                case "Card":
                    em.CallTouchEvent(HintKinds.Card);
                    break;
                case "Shovel":
                    em.CallTouchEvent(HintKinds.Shovel);
                    break;
                case "CallBox":
                    em.CallTouchEvent(HintKinds.CallBox);
                    break;
                case "Things":
                    em.CallTouchEvent(HintKinds.Things);
                    break;
                case "Parts":
                    em.CallTouchEvent(HintKinds.Parts);
                    break;
            }
        }
    }
}
