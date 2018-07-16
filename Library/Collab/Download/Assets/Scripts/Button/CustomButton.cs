using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomButton : MonoBehaviour {

    public PopupManager popupM;

	public virtual void OnClickButton()
    {
        foreach(var a in popupM.popupList)
        {
            a.SetActive(false);
        }
    }
}
