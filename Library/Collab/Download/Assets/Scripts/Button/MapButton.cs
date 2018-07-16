using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : CustomButton
{

    public GoogleMap map;

    public override void OnClickButton()
    {
        foreach (var a in popupM.popupList)
        {
            if (a != map.gameObject) a.SetActive(false);
        }
        map.gameObject.SetActive(!map.gameObject.activeSelf);
        if (map.gameObject.activeSelf)
        {
             map.Init();
        }
    }
}
