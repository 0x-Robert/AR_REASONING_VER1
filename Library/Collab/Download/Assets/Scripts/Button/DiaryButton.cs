using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryButton : CustomButton {

    public GameObject diary;

    public override void OnClickButton()
    {
        foreach (var a in popupM.popupList)
        {
            if(a != diary)a.SetActive(false);
        }
        diary.SetActive(!diary.activeSelf);
    }
}
